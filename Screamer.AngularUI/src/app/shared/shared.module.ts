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
import { FileUploadModule } from 'ng2-file-upload'; //Should import HERE
import { NgxSpinnerModule } from 'ngx-spinner';
import { PostComponent } from './components/post/post/post.component';
import { AddPostFormComponent } from './components/post/add-post-form/add-post-form.component';
import { AddPostComponent } from './components/post/add-post/add-post.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SafeHtmlPipe } from './pipes/safe-html-pipe.pipe';
import { UserCardComponent } from './components/card/user-card/user-card.component';
import { FollowComponent } from './components/buttons/follow/follow.component';
import { ChatComponent } from './components/buttons/chat/chat.component';
import { UserPostListComponent } from './components/list/user-post-list/user-post-list.component';
import { SideContentComponent } from './components/aside/side-content/side-content.component';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { FollowCardComponent } from './components/card/follow-card/follow-card.component';
import { FollowModalComponent } from './components/modal/follow-modal/follow-modal.component';
import { CoverUploadComponent } from './components/user/cover-upload/cover-upload.component';
import { SocialInputComponent } from './components/input/social-input/social-input.component';
import { ChatRoomTabComponent } from './components/chat/chat-room-tab/chat-room-tab.component';
import { SocialsListComponent } from './components/list/socials-list/socials-list.component';
import { CarouselComponent } from './components/carousel/carousel/carousel.component';
import { PostImagesUploadComponent } from './components/post/post-images-upload/post-images-upload.component';
import { ThumbnailDirective } from './directives/thumbnail.directive';

import { CarouselModule } from 'ngx-owl-carousel-o';

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
    SafeHtmlPipe,
    UserCardComponent,
    FollowComponent,
    ChatComponent,
    UserPostListComponent,
    SideContentComponent,
    FollowCardComponent,
    FollowModalComponent,
    CoverUploadComponent,
    SocialInputComponent,
    ChatRoomTabComponent,
    SocialsListComponent,
    CarouselComponent,
    PostImagesUploadComponent,
    ThumbnailDirective,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule,
    FileUploadModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
    InfiniteScrollModule,
    CarouselModule
  ],
  exports: [
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
    AvatarComponent,
    SafeHtmlPipe,
    UserCardComponent,
    FollowComponent,
    ChatComponent,
    UserPostListComponent,
    SideContentComponent,
    FollowModalComponent,
    CoverUploadComponent,
    SocialInputComponent,
    ChatRoomTabComponent,
    SocialsListComponent,
    CarouselComponent,
    PostImagesUploadComponent,
  ],
  providers: [],
})
export class SharedModule {}
