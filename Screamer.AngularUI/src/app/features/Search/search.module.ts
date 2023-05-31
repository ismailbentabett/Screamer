import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SearchRoutingModule } from './search-routing.module';
import { SearchListComponent } from './search-list/search-list.component';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';


@NgModule({
  declarations: [
    SearchListComponent
  ],
  imports: [
    CommonModule,
    SearchRoutingModule,
    InfiniteScrollModule
  ]
})
export class SearchModule { }
