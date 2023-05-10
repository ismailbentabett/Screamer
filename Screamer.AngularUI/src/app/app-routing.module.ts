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
    loadChildren: () =>
      import('./features/landing/landing.module').then((m) => m.LandingModule),
    canActivate: [loggedinGuard],
  },

  {
    path: 'auth',
    loadChildren: () =>
      import('./features/Auth/auth.module').then((m) => m.AuthModule),
    canActivate: [loggedinGuard],
  },

  {
    path: '',
    loadChildren: () =>
      import('./features/home/home.module').then((m) => m.HomeModule),
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
