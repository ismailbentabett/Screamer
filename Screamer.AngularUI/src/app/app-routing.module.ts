import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './features/Auth/signup/signup.component';
import { LoginComponent } from './features/Auth/login/login.component';

import { TestComponent } from './features/test/test.component';
import { authGuard } from './core/guards/auth.guard';
import { loggedinGuard } from './core/guards/loggedin.guard';
import { LandingComponent } from './features/landing/landing.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';

const routes: Routes = [

  {
    path: 'landing',
    component: LandingComponent,
    canActivate: [loggedinGuard],
  },
  {
    path: 'signup',
    component: SignupComponent,
    canActivate: [loggedinGuard],
  },
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [loggedinGuard],
  },
  {
    path: 'zabi',
    component: TestComponent,
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
  },

  { path: '**', pathMatch: 'full', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
