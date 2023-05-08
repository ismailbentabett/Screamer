import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Feature1RoutingModule } from './feature-1-routing.module';
import { MyPageComponent } from './pages/my-page/my-page.component';
import { MyComponenetComponent } from './componenets/my-componenet/my-componenet.component';


@NgModule({
  declarations: [
    MyPageComponent,
    MyComponenetComponent
  ],
  imports: [
    CommonModule,
    Feature1RoutingModule
  ]
})
export class Feature1Module { }
