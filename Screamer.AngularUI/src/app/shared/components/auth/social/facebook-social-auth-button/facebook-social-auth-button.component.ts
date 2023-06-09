import {
  FacebookLoginProvider,
  SocialAuthService,
} from '@abacritt/angularx-social-login';
import { Component } from '@angular/core';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-facebook-social-auth-button',
  templateUrl: './facebook-social-auth-button.component.html',
  styleUrls: ['./facebook-social-auth-button.component.scss'],
})
export class FacebookSocialAuthButtonComponent {
  constructor(
    public authService: AuthenticationService,
    private externalAuthService: SocialAuthService
  ) {
    this.externalAuthService.authState.subscribe((user) => {
      if (user) {
        if (user && user.provider === FacebookLoginProvider.PROVIDER_ID) {
          this.authService.externalfacebook({
            provider: 'Facebook',
            token: user.authToken,
          });
        }
      }
    });
  }


  facebookLogIn() {
    this.externalAuthService
      .signIn(FacebookLoginProvider.PROVIDER_ID)

  }
}
