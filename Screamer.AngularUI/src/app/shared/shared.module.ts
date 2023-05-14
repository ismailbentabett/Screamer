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
import { LoginAndSignupNavComponent } from './components/buttons/login-and-signup-nav/login-and-signup-nav.component';
import { AvatarUploadComponent } from './components/user/avatar-upload/avatar-upload.component';
import { FileUploadModule } from "ng2-file-upload";   //Should import HERE
import { NgxSpinnerModule } from 'ngx-spinner';
import { PostComponent } from './components/post/post/post.component';
import { AddPostFormComponent } from './components/post/add-post-form/add-post-form.component';
import { AddPostComponent } from './components/post/add-post/add-post.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    MyDirectiveDirective,
    MyPipePipe,
    NotFoundComponent,
    AvatarComponent,
    SidebarComponent,
    NavbarComponent,
    FooterComponent,
    LoginAndSignupNavComponent,
    AvatarUploadComponent,
    PostComponent,
    AddPostFormComponent,
    AddPostComponent,

  ],
  imports: [CommonModule, HttpClientModule , RouterModule , FileUploadModule , NgxSpinnerModule , ReactiveFormsModule],
  exports : [
    MyDirectiveDirective,
    MyPipePipe,
    NotFoundComponent,
    AvatarComponent,
    SidebarComponent,
    NavbarComponent,
    FooterComponent,
    LoginAndSignupNavComponent,
    AvatarUploadComponent,
    PostComponent,
    AddPostFormComponent,
    AddPostComponent,


  ]
})
export class SharedModule {}
