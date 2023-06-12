import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { ChatRoomTabComponent } from './components/chat/chat-room-tab/chat-room-tab.component';
import { SocialsListComponent } from './components/list/socials-list/socials-list.component';
import { CarouselComponent } from './components/carousel/carousel/carousel.component';
import { PostImagesUploadComponent } from './components/post/post-images-upload/post-images-upload.component';
import { ThumbnailDirective } from './directives/thumbnail.directive';

import { CarouselModule } from 'ngx-owl-carousel-o';
import { ReactionButtonComponent } from './components/buttons/reaction-button/reaction-button.component';
import { LovedComponent } from './components/reactions/loved/loved.component';
import { LikedComponent } from './components/reactions/liked/liked.component';
import { ScreamingComponent } from './components/reactions/screaming/screaming.component';
import { SadComponent } from './components/reactions/sad/sad.component';
import { HappyComponent } from './components/reactions/happy/happy.component';
import { ExcitedComponent } from './components/reactions/excited/excited.component';
import { CommentSectionComponent } from './components/post/comment-section/comment-section.component';
import { CommentInputComponent } from './components/post/comment-input/comment-input.component';
import { IntlModule } from 'angular-ecmascript-intl';
import { DateStuffPipe } from './pipes/date-stuff.pipe';
import { ClipboardModule } from 'ngx-clipboard';
import { SearchComponent } from './components/search/search/search.component';
import { SearchResultModalComponent } from './components/modal/search-result-modal/search-result-modal.component';
import { QuillModule } from 'ngx-quill';
import { CategoryModalComponent } from './components/modal/category-modal/category-modal.component';
import { TagModalComponent } from './components/modal/tag-modal/tag-modal.component';
import { PickerModule } from '@ctrl/ngx-emoji-mart';
import { ShortNumberPipe } from './pipes/short-number.pipe';
import { ShareButtonsModule } from 'ngx-sharebuttons/buttons';
import { ShareIconsModule } from 'ngx-sharebuttons/icons';
import { SharePostModalComponent } from './components/modal/share-post-modal/share-post-modal.component';
import { InputComponent } from './components/input/input/input.component';
import { AutocompleteOffDirective } from './directives/autocomplete-off.directive';
import { CommentDropDownComponent } from './components/dropdown/comment-drop-down/comment-drop-down.component';
import { GoogleSocialAuthButtonComponent } from './components/auth/social/google-social-auth-button/google-social-auth-button.component';
import { FacebookSocialAuthButtonComponent } from './components/auth/social/facebook-social-auth-button/facebook-social-auth-button.component';
import {
  FacebookLoginProvider,
  GoogleLoginProvider,
  GoogleSigninButtonModule,
  SocialAuthServiceConfig,
} from '@abacritt/angularx-social-login';
import { environment } from 'src/environments/environment';
import { DeleteMyAccountModalComponent } from './components/modal/delete-my-account-modal/delete-my-account-modal.component';
import { DeleteUserModalComponent } from './components/modal/delete-user-modal/delete-user-modal.component';
import { DeletePostModalComponent } from './components/modal/delete-post-modal/delete-post-modal.component';
import { DeleteCommentModalComponent } from './components/modal/delete-comment-modal/delete-comment-modal.component';
import { StoriesCarouselComponent } from './components/stories/stories-carousel/stories-carousel.component';
import { StoryComponent } from './components/stories/story/story.component';
import { StoryEditorComponent } from './components/stories/story-editor/story-editor.component';
import { StoryEditorFullscreenModalComponent } from './components/stories/story-editor-fullscreen-modal/story-editor-fullscreen-modal.component';

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
    ChatRoomTabComponent,
    SocialsListComponent,
    CarouselComponent,
    PostImagesUploadComponent,
    ThumbnailDirective,
    ReactionButtonComponent,
    LovedComponent,
    LikedComponent,
    ScreamingComponent,
    SadComponent,
    HappyComponent,
    ExcitedComponent,
    CommentSectionComponent,
    CommentInputComponent,
    DateStuffPipe,
    SearchComponent,
    SearchResultModalComponent,
    CategoryModalComponent,
    TagModalComponent,
    ShortNumberPipe,
    SharePostModalComponent,
    InputComponent,
    AutocompleteOffDirective,
    CommentDropDownComponent,
    GoogleSocialAuthButtonComponent,
    FacebookSocialAuthButtonComponent,
    DeleteMyAccountModalComponent,
    DeleteUserModalComponent,
    DeletePostModalComponent,
    DeleteCommentModalComponent,
    StoriesCarouselComponent,
    StoryComponent,
    StoryEditorComponent,
    StoryEditorFullscreenModalComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule,
    FileUploadModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
    InfiniteScrollModule,
    CarouselModule,
    IntlModule,
    ClipboardModule,
    FormsModule,
    QuillModule.forRoot(),
    PickerModule,
    ShareButtonsModule,
    ShareIconsModule,
    GoogleSigninButtonModule,
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
    ChatRoomTabComponent,
    SocialsListComponent,
    CarouselComponent,
    PostImagesUploadComponent,
    ReactionButtonComponent,
    LovedComponent,
    LikedComponent,
    ScreamingComponent,
    SadComponent,
    HappyComponent,
    ExcitedComponent,
    CommentSectionComponent,
    CommentInputComponent,
    SearchResultModalComponent,
    CategoryModalComponent,
    TagModalComponent,
    SharePostModalComponent,
    InputComponent,
    AutocompleteOffDirective,
    CommentDropDownComponent,
    GoogleSocialAuthButtonComponent,
    FacebookSocialAuthButtonComponent,
    DeleteMyAccountModalComponent,
    DeleteUserModalComponent,
    DeletePostModalComponent,
    DeleteCommentModalComponent,
    StoriesCarouselComponent,
    StoryComponent,
    StoryEditorComponent,
    StoryEditorFullscreenModalComponent,
  ],
  providers: [
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(environment.Google.ClientId, {
              scopes: 'email',
            }),
          },
          {
            id: FacebookLoginProvider.PROVIDER_ID,

            provider: new FacebookLoginProvider(environment.Facebook.AppId),
          },
        ],
        onError: (err) => {
          console.error(err);
        },
      } as SocialAuthServiceConfig,
    },
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class SharedModule {}
