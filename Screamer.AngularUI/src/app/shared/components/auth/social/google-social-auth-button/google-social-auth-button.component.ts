import { SocialAuthService } from '@abacritt/angularx-social-login';
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

        console.log(user)

        this.authService.externalfacebook({
          provider: 'Facebook',
          token: user.authToken,
        });
     /*    const accessToken = user.idToken;

        this.authService.externallogin({
          provider: 'Google',
          token: accessToken,
        }); */
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
      { theme: 'outline', size: 'large', width: '100%' }
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
