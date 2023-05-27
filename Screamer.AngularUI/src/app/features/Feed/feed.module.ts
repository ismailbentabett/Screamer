import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FeedRoutingModule } from './feed-routing.module';
import { FeedComponent } from './feed/feed.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { RecentFeedComponent } from './recent-feed/recent-feed.component';
import { ForYouFeedComponent } from './for-you-feed/for-you-feed.component';
import { FollowingFeedComponent } from './following-feed/following-feed.component';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';

@NgModule({
  declarations: [
    FeedComponent,
    RecentFeedComponent,
    ForYouFeedComponent,
    FollowingFeedComponent,
  ],
  imports: [
    CommonModule,
    FeedRoutingModule,
    SharedModule,
    InfiniteScrollModule,
  ],
})
export class FeedModule {}
