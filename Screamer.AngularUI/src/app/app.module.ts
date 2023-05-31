import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FeaturesModule } from './features/features.module';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';

import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './core/interceptors/jwt.interceptor';
import { LoadingInterceptor } from './core/interceptors/loading.interceptor';
import { JwtModule } from "@auth0/angular-jwt";
import { HttpClientModule } from "@angular/common/http";
import { ToastrModule } from 'ngx-toastr';

export function tokenGetter() {
  return localStorage.getItem('token');
}


@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    FeaturesModule,
    CoreModule,
    HttpClientModule,
    SharedModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter
      },
    }),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},

  ],

  bootstrap: [AppComponent],
})
export class AppModule {}
