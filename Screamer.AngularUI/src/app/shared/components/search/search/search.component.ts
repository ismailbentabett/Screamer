// search.component.ts

import {
  Component,
  EventEmitter,
  Input,
  Output,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { InfiniteScrollDirective } from 'ngx-infinite-scroll';
import { SearchService } from 'src/app/core/services/search.service';
import {
  trigger,
  state,
  style,
  transition,
  animate,
} from '@angular/animations';
import { head } from 'lodash';
@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],

  animations: [
    trigger('dropdownAnimation', [
      state(
        'open',
        style({
          transform: 'opacity-100 scale-100',
          opacity: 1,
        })
      ),
      state(
        'closed',
        style({
          transform: 'opacity-0 scale-95',
          opacity: 0,
        })
      ),
      transition('closed => open', animate('100ms ease-out')),
      transition('open => closed', animate('75ms ease-in')),
    ]),
  ],
})
export class SearchComponent {
  searchQuery: string = '';

  constructor(public searchService: SearchService) {}

  search() {
    this.searchService.setSearchQuery(this.searchQuery);
    this.searchService.search().then((data) => {
      console.log(this.searchService.searchResults);
    });
  }

  isOpen = false;

  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }

  getFirstImage(array: any) {
    let data: any = head(JSON.parse(array as any));
    if (data) {
      return data!.url;
    }
    return false;
  }

  openSearchModal(){
    this.searchService.openPopup();
  }
}
