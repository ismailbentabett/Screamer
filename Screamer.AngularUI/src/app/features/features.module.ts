import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './Auth/login/login.component';
import { SignupComponent } from './Auth/signup/signup.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { AccountModule } from './Account/account.module';
import { SharedModule } from '../shared/shared.module';
import { ProfileComponent } from './Settings/profile/profile.component';
import { AccountComponent } from './Settings/account/account.component';
import { AuthComponent } from './Settings/auth/auth.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    LoginComponent,
    SignupComponent,
    LandingComponent,
    ProfileComponent,
    AccountComponent,
    AuthComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    AccountModule,
    SharedModule,
    NgxSpinnerModule,
    BrowserAnimationsModule
  ],
  exports: [LoginComponent, SignupComponent],
})
export class FeaturesModule {}
