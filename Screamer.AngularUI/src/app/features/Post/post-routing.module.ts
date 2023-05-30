import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowPostComponent } from './show-post/show-post.component';
import { EditPostComponent } from './edit-post/edit-post.component';
import { PostContainerComponent } from './post-container/post-container.component';

const routes: Routes = [
  {
    path: '',
    component: PostContainerComponent,
    children: [
      {
        path: ':postId',
        component: ShowPostComponent,
      },
      {
        path: ':postId/edit',
        component: EditPostComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PostRoutingModule {}
