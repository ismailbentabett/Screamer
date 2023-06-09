import {
  GoogleLoginProvider,
  SocialAuthService,
} from '@abacritt/angularx-social-login';
import { Component, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-google-social-auth-button',
  templateUrl: './google-social-auth-button.component.html',
  styleUrls: ['./google-social-auth-button.component.scss'],
})
export class GoogleSocialAuthButtonComponent {
  constructor(
    public authService: AuthenticationService,
    private router: Router,
    private externalAuthService: SocialAuthService,
    private ngZone: NgZone
  ) {
    this.externalAuthService.authState.subscribe((user) => {
      if (user) {
        if (user && user.provider === GoogleLoginProvider.PROVIDER_ID) {
          const accessToken = user.idToken;
          this.authService.externallogin({
            provider: 'Google',
            token: accessToken,
          });
        }

        /*   this.authService.externalfacebook({
          provider: 'Facebook',
          token: user.authToken,
        }); */
        /*    ;

        */
      }
    });
  }

  ngOnInit(): void {
    // @ts-ignore
    google.accounts.id.initialize({
      client_id: environment.Google.ClientId,
      callback: this.handleCredentialResponse.bind(this),
      auto_select: false,
      cancel_on_tap_outside: true,
    });
    // @ts-ignore
    google.accounts.id.renderButton(
      // @ts-ignore
      document.getElementById('google-button'),
      {
        /* type	The button type: icon, or standard button.
theme	The button theme. For example, filled_blue or filled_black.
size	The button size. For example, small or large.
text	The button text. For example, "Sign in with Google" or "Sign up with Google".
shape	The button shape. For example, rectangular or circular.
logo_alignment	The Google logo alignment: left or center.
width	The button width, in pixels.
locale */

        theme: 'outline',
        size: 'large',
        text: 'Sign in with Google',
        shape: 'rectangular',
        logo_alignment: 'left',
        locale: 'en',
      }
    );
    // @ts-ignore
    google.accounts.id.prompt((notification: PromptMomentNotification) => {});
  }

  handleCredentialResponse(response: any) {
    this.ngZone.run(() => {
      if (response.credential) {
        this.authService.externallogin({
          provider: 'Google',
          token: response.credential,
        });
      }
    });
  }
}
