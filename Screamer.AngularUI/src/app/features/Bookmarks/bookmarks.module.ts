import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BookmarksRoutingModule } from './bookmarks-routing.module';
import { BookmarkFeedComponent } from './bookmark-feed/bookmark-feed.component';


@NgModule({
  declarations: [
    BookmarkFeedComponent
  ],
  imports: [
    CommonModule,
    BookmarksRoutingModule
  ]
})
export class BookmarksModule { }
