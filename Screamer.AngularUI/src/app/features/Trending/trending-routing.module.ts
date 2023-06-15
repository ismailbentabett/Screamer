import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TrendingComponent } from './trending/trending.component';
import { TrendingFeedComponent } from './trending-feed/trending-feed.component';
import { TrendingPopularComponent } from './trending-popular/trending-popular.component';
import { TrendingUsersComponent } from './trending-users/trending-users.component';

const routes: Routes = [
  {
    path: '',
    component: TrendingComponent,
    children: [
      {
        path: '',
        redirectTo: 'posts',
        pathMatch: 'full',
      },
      {
        path: 'posts',
        component: TrendingFeedComponent,
      },
      {
        path: 'popular',
        component: TrendingPopularComponent,
      },
      {
        path: 'following',
        component: TrendingUsersComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TrendingRoutingModule {}
