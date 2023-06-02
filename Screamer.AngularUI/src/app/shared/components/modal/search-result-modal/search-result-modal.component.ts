import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { head } from 'lodash';
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
  constructor(public searchService: SearchService, private router: Router) {}

  openPopup() {
    this.searchService.openPopup();
  }

  closePopup() {
    this.searchService.closePopup();
  }

  getObjectKey(object: any, index: any) {
    return Object.keys(object)[index];
  }

  getFirstImage(array: any) {
    let data: any = head(JSON.parse(array as any));
    if (data) {
      return data!.url;
    }
    return false;
  }

  routeToResult(id: any, key: any) {

    if (key == 'post') {

      this.router.navigate(['/v/post', id]);
    } else if ((key = 'user')) {
      this.router.navigate(['/v/user', id]);
    }
    this.searchService.searchQuery = '';
    this.searchService.closePopup();
  }
}
