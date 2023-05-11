import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyDirectiveDirective } from './directives/my-directive.directive';
import { MyPipePipe } from './pipes/my-pipe.pipe';

import { HttpClientModule } from '@angular/common/http';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { FeaturesModule } from '../features/features.module';
import { CoreModule } from '../core/core.module';
import { AvatarComponent } from './components/user/avatar/avatar.component';
import { SidebarComponent } from './components/aside/sidebar/sidebar.component';

@NgModule({
  declarations: [
    MyDirectiveDirective,
    MyPipePipe,
    NotFoundComponent,
    AvatarComponent,
    SidebarComponent,
  ],
  imports: [CommonModule, HttpClientModule],
  exports : [
    MyDirectiveDirective,
    MyPipePipe,
    NotFoundComponent,
    AvatarComponent,
    SidebarComponent,
  ]
})
export class SharedModule {}
