import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SignupRoutingModule } from './signup-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { GoogleSigninButtonModule } from '@abacritt/angularx-social-login';

import {
  SocialLoginModule,
  SocialAuthServiceConfig,
} from '@abacritt/angularx-social-login';
import {
  GoogleLoginProvider,
  FacebookLoginProvider,
  MicrosoftLoginProvider,
} from '@abacritt/angularx-social-login';
import { environment } from 'src/environments/environment';
import { GoogleSigninButtonDirective } from '@abacritt/angularx-social-login';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SignupRoutingModule,
    SharedModule,
    SocialLoginModule,
    GoogleSigninButtonModule,

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
          {
            id: MicrosoftLoginProvider.PROVIDER_ID,
            provider: new MicrosoftLoginProvider(
              environment.Microsoft.ClientId,
              {
                scopes: ['email'],
              }
            ),
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
export class SignupModule {}
