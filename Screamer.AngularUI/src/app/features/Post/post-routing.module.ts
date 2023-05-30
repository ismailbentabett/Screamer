import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowPostComponent } from './show-post/show-post.component';
import { EditPostComponent } from './edit-post/edit-post.component';

const routes: Routes = [
  {
    path: '',
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
