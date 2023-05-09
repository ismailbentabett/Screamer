import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './features/Auth/signup/signup.component';
import { LoginComponent } from './features/Auth/login/login.component';

const routes: Routes = [
  {
    path: 'signup',
    component : SignupComponent
  },
  {
    path: 'login',
    component : LoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes),],
  exports: [RouterModule]
})
export class AppRoutingModule { }
