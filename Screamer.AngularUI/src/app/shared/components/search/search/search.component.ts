// search.component.ts

import {
  Component,
  ElementRef,
  EventEmitter,
  Input,
  Output,
  Renderer2,
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
import { NavigationEnd, Router } from '@angular/router';
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
  @ViewChild('searchInput') searchInput!: ElementRef;
  cantEnter!: boolean;

  constructor(
    public searchService: SearchService,
    private renderer: Renderer2,
    private router: Router
  ) {}


  ngOnInit () : void {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.cantEnter =
          this.router.url !== '/v/search/users' &&
          this.router.url !== '/v/search/posts';
      }
    });
  }
  ngAfterViewInit() {
    this.renderer.selectRootElement(this.searchInput.nativeElement).focus();
  }
  onInputFocus() {
    this.renderer.selectRootElement(this.searchInput.nativeElement).focus();
  }
  search() {
    this.searchService.setSearchQuery(this.searchService.searchQuery);
    this.openSearchModal();
    this.searchService.search()!.then((data) => {
      console.log(this.searchService.searchResults);
    });
  }

  isOpen = false;

  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }

  openSearchModal() {
    this.searchService.openPopup();
  }

  onEnter() {
    if ((this.searchService.searchQuery!== '' && !this.cantEnter)) {
      this.router.navigate(['/v/search']);
    }
  }
}
