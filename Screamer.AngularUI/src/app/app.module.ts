import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FeaturesModule } from './features/features.module';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { JwtHelperService } from '@auth0/angular-jwt/lib/jwthelper.service';
import { AuthGuard } from './core/guards/auth.guard';
import { JwtModule } from '@auth0/angular-jwt';
export function tokenGetter() {
  return localStorage.getItem("access_token");
}
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FeaturesModule,
    SharedModule,
    CoreModule
  ],
  providers: [
    AuthGuard   ],
  bootstrap: [AppComponent]
})
export class AppModule { }
