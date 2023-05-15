import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ListsRoutingModule } from './lists-routing.module';
import { UserListComponent } from './user-list/user-list.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    UserListComponent
  ],
  imports: [
    CommonModule,
    ListsRoutingModule,
    SharedModule
  ]
})
export class ListsModule { }
