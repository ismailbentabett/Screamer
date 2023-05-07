import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyComponentComponent } from './components/my-component/my-component.component';
import { MyDirectiveDirective } from './directives/my-directive.directive';
import { MyPipePipe } from './pipes/my-pipe.pipe';



@NgModule({
  declarations: [
    MyComponentComponent,
    MyDirectiveDirective,
    MyPipePipe
  ],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
