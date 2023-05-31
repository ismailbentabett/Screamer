import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SearchListComponent } from './search-list/search-list.component';
import { SearchPostListComponent } from './search-post-list/search-post-list.component';
import { SearchUserListComponent } from './search-user-list/search-user-list.component';

const routes: Routes = [
  {
    path: '',
    component: SearchListComponent,

    children: [
      { path: '', redirectTo: 'posts', pathMatch: 'full' },
      {
        path: 'posts',
        component: SearchPostListComponent,
      },
      {
        path: 'users',
        component: SearchUserListComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SearchRoutingModule {}
