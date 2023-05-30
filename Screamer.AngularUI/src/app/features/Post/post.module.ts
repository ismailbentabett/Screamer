import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PostRoutingModule } from './post-routing.module';
import { ShowPostComponent } from './show-post/show-post.component';
import { EditPostComponent } from './edit-post/edit-post.component';

@NgModule({
  declarations: [ShowPostComponent, EditPostComponent],
  imports: [CommonModule, PostRoutingModule],
})
export class PostModule {}
