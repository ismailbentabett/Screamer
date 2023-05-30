import { Injectable } from '@angular/core';
import algoliasearch from 'algoliasearch';
import { environment } from './../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  private client: any;
  private index: any;
  ApplicationId = environment.ApplicationId;
  APIKey = environment.APIKey;
  constructor() {
    this.client = algoliasearch(this.ApplicationId, this.APIKey);
    this.index = this.client.initIndex('post');
  }
 /* requestOptions?: RequestOptions & SearchOptions */
  searchOptions : any = {
  hitsPerPage: 10, // Number of results to retrieve per index
};
  search(query: string ) {
    return this.index.search(query , this.searchOptions);
  }
}
