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

  search(query: string) {
    return this.index.search(query);
  }
}
