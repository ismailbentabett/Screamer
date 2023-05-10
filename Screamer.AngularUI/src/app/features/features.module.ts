import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './Auth/login/login.component';
import { SignupComponent } from './Auth/signup/signup.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TestComponent } from './test/test.component';
import { RouterModule } from '@angular/router';
import { LandingComponent } from './landing/landing.component';



@NgModule({
  declarations: [
    LoginComponent,
    SignupComponent,
    TestComponent,
    LandingComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ],
  exports: [
    LoginComponent,
    SignupComponent,
    TestComponent
  ],
})
export class FeaturesModule { }
