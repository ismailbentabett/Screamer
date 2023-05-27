import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FeedComponent } from './feed/feed.component';
import { RecentFeedComponent } from './recent-feed/recent-feed.component';
import { ForYouFeedComponent } from './for-you-feed/for-you-feed.component';
import { FollowingFeedComponent } from './following-feed/following-feed.component';

const routes: Routes = [
  {
    path: '',
    component: FeedComponent,
    children: [
      {
        path: '',
        redirectTo: 'recent',
        pathMatch: 'full',
      },
      {
        path: 'recent',
        component: RecentFeedComponent,
      },
      {
        path: 'for-you',
        component: ForYouFeedComponent,
      },
      {
        path: 'following',
        component: FollowingFeedComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class FeedRoutingModule {}
