import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HashtagFeedComponent } from './hashtag-feed/hashtag-feed.component';

const routes: Routes = [  {
  path: '',
  children: [
    {
      path: ':hashtag',
      component: HashtagFeedComponent,
    },
  ],
},];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HashtagRoutingModule { }
