import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './features/Auth/signup/signup.component';
import { LoginComponent } from './features/Auth/login/login.component';

import { TestComponent } from './features/test/test.component';
import { authGuard } from './core/guards/auth.guard';

const routes: Routes = [
  {
    path: 'signup',
    component : SignupComponent
  },
  {
    path: 'login',
    component : LoginComponent,

  },
  {
    path: 'zabi',
    component : TestComponent,
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes),],
  exports: [RouterModule]
})
export class AppRoutingModule { }
