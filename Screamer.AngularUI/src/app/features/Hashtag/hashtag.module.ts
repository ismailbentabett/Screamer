import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HashtagRoutingModule } from './hashtag-routing.module';
import { HashtagFeedComponent } from './hashtag-feed/hashtag-feed.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { HashtagComponent } from './hashtag/hashtag.component';

@NgModule({
  declarations: [HashtagFeedComponent, HashtagComponent],
  imports: [CommonModule, HashtagRoutingModule, SharedModule],
})
export class HashtagModule {}
