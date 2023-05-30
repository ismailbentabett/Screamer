// search.component.ts

import { Component } from '@angular/core';
import { SearchService } from 'src/app/core/services/search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
})
export class SearchComponent {
  searchQuery: string = '';
  searchResults: any;

  constructor(private algoliaService: SearchService) {}

  onSearch() {
    this.algoliaService.search(this.searchQuery)
      .then((response: any) => {
        console.log(response)
        this.searchResults = response;
      })
      .catch((error: any) => {
        console.error('Algolia search error:', error);
      });
  }
}
