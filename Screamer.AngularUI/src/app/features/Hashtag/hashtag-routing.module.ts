import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HashtagFeedComponent } from './hashtag-feed/hashtag-feed.component';
import { HashtagComponent } from './hashtag/hashtag.component';

const routes: Routes = [
  {
    path: '',
    component: HashtagComponent,
    children: [
      {
        path: '',
        redirectTo: ':hashtag',
        pathMatch: 'full',
      },
      {
        path: ':hashtag',
        component: HashtagFeedComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HashtagRoutingModule {}
