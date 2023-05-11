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
import { NavbarComponent } from './components/header/navbar/navbar.component';
import { FooterComponent } from './components/bottom/footer/footer.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    MyDirectiveDirective,
    MyPipePipe,
    NotFoundComponent,
    AvatarComponent,
    SidebarComponent,
    NavbarComponent,
    FooterComponent,
  ],
  imports: [CommonModule, HttpClientModule , RouterModule],
  exports : [
    MyDirectiveDirective,
    MyPipePipe,
    NotFoundComponent,
    AvatarComponent,
    SidebarComponent,
    NavbarComponent,
    FooterComponent,
  ]
})
export class SharedModule {}
