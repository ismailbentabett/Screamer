import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ListsRoutingModule } from './lists-routing.module';
import { UserListComponent } from './user-list/user-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { AccordionModule } from 'ngx-bootstrap/accordion';


@NgModule({
  declarations: [
    UserListComponent
  ],
  imports: [
    CommonModule,
    ListsRoutingModule,
    SharedModule,
    PaginationModule.forRoot(),
    AccordionModule.forRoot()
  ]
})
export class ListsModule { }
