import { Injectable } from '@angular/core';
import algoliasearch from 'algoliasearch';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  private client: any;
  private index: any;

  constructor() {
    this.client = algoliasearch(
      'M5MXJTPNYY',
      '432541b28332ed3c76ac1103ec7ca3ce'
    );
    this.index = this.client.initIndex('post');
  }

  search(query: string) {
    return this.index.search(query);
  }
}
