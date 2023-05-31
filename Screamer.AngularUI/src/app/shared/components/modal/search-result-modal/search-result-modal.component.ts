import { Component } from '@angular/core';
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
  constructor(public searchService: SearchService) {

  }


  openPopup() {
    this.searchService.openPopup();
  }

  closePopup() {
    this.searchService.closePopup();
  }

  getObjectKey(object: any , index : any) {
    console.log(object , ' ' , index)
    return Object.keys(object)[index];
  }

  getFirstImage(array: any) {
    let data: any = head(JSON.parse(array as any));
    if (data) {
      return data!.url;
    }
    return false;
  }
}
