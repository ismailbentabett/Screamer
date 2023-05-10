import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home.component';
import { TestComponent } from '../test/test.component';

const routes: Routes = [
  {
    path: '',
    component : HomeComponent ,
    children : [
      {
        path: 'landing',
        component : TestComponent
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
