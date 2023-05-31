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
  public hitsPerPage: number = 7;
  public searchQuery: string = '';
  public currentPage: number = 0;
  searchResults: BehaviorSubject<any> = new BehaviorSubject<any>([]);
  public isOpen: boolean = false;

  constructor() {
    this.client = algoliasearch(environment.ApplicationId, environment.APIKey);

    this.indexes['post'] = this.client.initIndex('post');
    this.indexes['user'] = this.client.initIndex('user');
    // Add more index names and initialize them as needed
  }

  openPopup() {
    this.isOpen = true;
  }

  closePopup() {
    this.isOpen = false;
  }

  setSearchQuery(query: string) {
    this.searchQuery = query;
  }
  getSearchQuery() {
    return this.searchQuery;
  }

  search() {
    if (this.searchQuery == '') return this.client.multipleQueries([]);
    const queries = Object.values(this.indexes).map((index) => ({
      indexName: index.indexName,
      query: this.searchQuery,
      params: {
        page: 0,
        hitsPerPage: this.hitsPerPage,
      },
    }));

    return this.client.multipleQueries(queries).then((response) => {
      //seperate result by index array of objects
      let results: any = {};
      response.results.forEach((result: any) => {
        results[result.index] = result.hits;
      });
      const arrayOfObjects = Object.entries(results).map(([key, value]) => ({ key, value }));

      console.log(arrayOfObjects)
      this.searchResults.next(arrayOfObjects);
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
