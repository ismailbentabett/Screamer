import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { authGuard } from './core/guards/auth.guard';
import { loggedinGuard } from './core/guards/loggedin.guard';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';

const routes: Routes = [
  {
    path: '',
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
    path: 'v',
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      {
        path: '',
        loadChildren: () =>
          import('./features/Account/account.module').then(
            (m) => m.AccountModule
          ),
      },
      {
        path: 'feed',
        loadChildren: () =>
          import('./features/Feed/feed.module').then((m) => m.FeedModule),
      },
      {
        path: 'settings',
        loadChildren: () =>
          import('./features/Settings/settings.module').then(
            (m) => m.SettingsModule
          ),
      },
      {
        path: 'list',
        loadChildren: () =>
          import('./features/Lists/lists.module').then((m) => m.ListsModule),
      },
      {
        path: 'chat',
        loadChildren: () =>
          import('./features/Chat/chat.module').then((m) => m.ChatModule),
      },
      {
        path: 'post',
        loadChildren: () =>
          import('./features/Post/post.module').then((m) => m.PostModule),
      },
      {
        path: 'search',
        loadChildren: () =>
          import('./features/Search/search.module').then((m) => m.SearchModule),
      },
    ],
  },

  { path: '**', pathMatch: 'full', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
