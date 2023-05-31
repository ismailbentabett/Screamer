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

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
})
export class SearchComponent {
  searchQuery: string = '';

  constructor(public searchService: SearchService) {}

  search() {
    this.searchService.setSearchQuery(this.searchQuery);
    this.searchService.search().then((data)=>{
      console.log(data);
    })
  }
}
