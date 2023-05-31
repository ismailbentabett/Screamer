import { Injectable } from '@angular/core';
import algoliasearch, { SearchClient, SearchIndex } from 'algoliasearch';
import { environment } from './../../../environments/environment';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  public client: SearchClient;
  public indexes: { [indexName: string]: SearchIndex } = {};
  public hitsPerPage: number = 10;
  public searchQuery: string = '';
  public currentPage: number = 0;
  searchResults: BehaviorSubject<any[]> = new BehaviorSubject<any[]>([]);

  constructor() {
    this.client = algoliasearch(environment.ApplicationId, environment.APIKey);

    this.indexes['post'] = this.client.initIndex('post');
    this.indexes['user'] = this.client.initIndex('user');
    // Add more index names and initialize them as needed
  }

  setSearchQuery(query: string) {
    this.searchQuery = query;
  }

  search() {
    const queries = Object.values(this.indexes).map((index) => ({
      indexName: index.indexName,
      query: this.searchQuery,
      params: {
        page: 0,
        hitsPerPage: this.hitsPerPage,
      },
    }));

    return this.client.multipleQueries(queries).then((response) => {
      const results = response.results.map((result) => result.hits).flat();
      this.searchResults.next(results);
      this.currentPage = 0; // Reset current page
    });
  }

  getPaginatedResults() {
    this.currentPage++; // Increment current page

    const queries = Object.values(this.indexes).map((index) => ({
      indexName: index.indexName,
      query: this.searchQuery,
      params: {
        page: this.currentPage,
        hitsPerPage: this.hitsPerPage,
      },
    }));

    return this.client.multipleQueries(queries);
  }
}
