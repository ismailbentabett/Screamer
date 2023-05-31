import { Component } from '@angular/core';
import { SearchService } from 'src/app/core/services/search.service';

@Component({
  selector: 'app-search-user-list',
  templateUrl: './search-user-list.component.html',
  styleUrls: ['./search-user-list.component.scss'],
})
export class SearchUserListComponent {
  hasMoreResults: boolean = true;

  constructor(public searchService: SearchService) {}

  loadMore() {
    this.searchService.getPaginatedResults().then((response) => {
      const results = response.results.map((result) => result.hits).flat();

      if (results.length === 0) {
        this.hasMoreResults = false;
      }

      this.searchService.searchResults.next([
        ...this.searchService.searchResults.value,
        ...results,
      ]);
    });
  }
}
