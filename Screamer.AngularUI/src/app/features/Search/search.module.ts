import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SearchRoutingModule } from './search-routing.module';
import { SearchListComponent } from './search-list/search-list.component';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { SharedModule } from 'src/app/shared/shared.module';
import { SearchPostListComponent } from './search-post-list/search-post-list.component';
import { SearchUserListComponent } from './search-user-list/search-user-list.component';


@NgModule({
  declarations: [
    SearchListComponent,
    SearchPostListComponent,
    SearchUserListComponent
  ],
  imports: [
    CommonModule,
    SearchRoutingModule,
    InfiniteScrollModule,
    SharedModule
  ]
})
export class SearchModule { }
