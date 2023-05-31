import { Component } from '@angular/core';
import { SearchService } from 'src/app/core/services/search.service';

@Component({
  selector: 'app-search-result-modal',
  templateUrl: './search-result-modal.component.html',
  styleUrls: ['./search-result-modal.component.scss'],
})
export class SearchResultModalComponent {
  /**
   *
   */
  constructor(private searchService: SearchService) {}
  openPopup() {
    this.searchService.openPopup();
  }

  closePopup() {
    this.searchService.closePopup();
  }
}
