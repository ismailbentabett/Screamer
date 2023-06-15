import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryFeedComponent } from './category-feed/category-feed.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: ':category',
        component: CategoryFeedComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CategoryRoutingModule {}
