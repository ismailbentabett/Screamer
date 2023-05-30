import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PostRoutingModule } from './post-routing.module';
import { ShowPostComponent } from './show-post/show-post.component';
import { EditPostComponent } from './edit-post/edit-post.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [ShowPostComponent, EditPostComponent],
  imports: [CommonModule, PostRoutingModule, SharedModule],
})
export class PostModule {}
