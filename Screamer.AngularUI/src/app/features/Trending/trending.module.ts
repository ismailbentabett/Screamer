import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TrendingRoutingModule } from './trending-routing.module';
import { TrendingComponent } from './trending/trending.component';
import { TrendingFeedComponent } from './trending-feed/trending-feed.component';
import { TrendingPopularComponent } from './trending-popular/trending-popular.component';
import { TrendingUsersComponent } from './trending-users/trending-users.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    TrendingComponent,
    TrendingFeedComponent,
    TrendingPopularComponent,
    TrendingUsersComponent,
  ],
  imports: [
    CommonModule,
    TrendingRoutingModule,
    SharedModule
  ]
})
export class TrendingModule { }
