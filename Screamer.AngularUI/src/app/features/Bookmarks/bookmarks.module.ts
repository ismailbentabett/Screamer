import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BookmarksRoutingModule } from './bookmarks-routing.module';
import { BookmarkFeedComponent } from './bookmark-feed/bookmark-feed.component';
import { share } from 'rxjs';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    BookmarkFeedComponent
  ],
  imports: [
    CommonModule,
    BookmarksRoutingModule,
    SharedModule
  ]
})
export class BookmarksModule { }
