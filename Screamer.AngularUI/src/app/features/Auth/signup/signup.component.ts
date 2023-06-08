import { Component, NgZone } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { ValidationService } from 'src/app/core/services/validation.service';
import {
  GoogleLoginProvider,
  FacebookLoginProvider,
  MicrosoftLoginProvider,
  SocialAuthService,
} from '@abacritt/angularx-social-login';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent {
  form: FormGroup;
  gapi: any;

  constructor(
    private fb: FormBuilder,
    public authService: AuthenticationService,
    private router: Router,
    private validationService: ValidationService,
    private externalAuthService: SocialAuthService,
    private ngZone: NgZone
  ) {
    window['authRef' as any] = {
      component: this,
      zone: this.ngZone,
      googleSigninFunction: (e: any) => this.onGoogleSignin(e),
    } as any;

    this.externalAuthService.authState.subscribe((user) => {
      if (user) {
        const accessToken = user.idToken;

        this.authService.externallogin({
          provider: 'Google',
          token: accessToken,
        });
      }
    });
    this.form = this.fb.group({
      firstName: [
        '',
        [
          Validators.required,
          this.validationService.noNumbers,
          this.validationService.nospecialCharactersValidator,
          this.validationService.noWhitespace,
        ],
      ],
      lastName: [
        '',
        [
          Validators.required,
          this.validationService.noNumbers,
          this.validationService.nospecialCharactersValidator,
          this.validationService.noWhitespace,
        ],
      ],
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(20),
          this.validationService.specialCharactersValidator,
          this.validationService.noWhitespace,
          this.validationService.Numbers,
        ],
      ],
      userName: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          this.validationService.noWhitespace,
        ],
      ],
    });
  }

  onGoogleSignin(e: any) {
    console.log(e);
  }

  signInWithGoogle() {
    this.gapi.load('auth2', () => {
      this.gapi.auth2
        .init({
          client_id:
            '976991747422-62077tsg6vtp3sg4d483kmmnh3amsb99.apps.googleusercontent.com',
        })
        .then(() => {
          this.gapi.auth2
            .getAuthInstance()
            .signIn()
            .then((user: any) => {
              this.ngZone.run(() => {
                this.googleSignInCallback(user);
              });
            });
        });
    });
  }

  googleSignInCallback(response: any) {
    // Handle the Google Sign-In response here
    console.log('Google Sign-In Response:', response);
    // Perform further actions based on the response
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
  onSubmit() {
    if (!this.form.valid) return;
    this.authService.register(this.form.value).subscribe(
      () => {
        this.router.navigate(['/auth/login']);
      },
      (error) => console.error('Registration failed', error)
    );
  }

  googleLogIn() {
    this.externalAuthService
      .signIn(GoogleLoginProvider.PROVIDER_ID)
      .then((user: any) => {
        if (user) {
        }
      })
      .catch((error) => {
        console.log(error);
      });
  }

  facebookLogIn() {
    this.externalAuthService
      .signIn(FacebookLoginProvider.PROVIDER_ID)
      .then((user: any) => {
        if (user) {
          const accessToken = user.authToken;
          this.authService.externallogin({
            provider: 'Google',
            token: accessToken,
          });
        }
      })
      .catch((error) => {
        console.log(error);
      });
  }

  microsoftLogIn() {
    this.externalAuthService
      .signIn(MicrosoftLoginProvider.PROVIDER_ID)
      .then((user: any) => {
        if (user) {
          const accessToken = user.authToken;
          this.authService.externallogin({
            provider: 'Google',
            token: accessToken,
          });
        }
      })
      .catch((error) => {
        console.log(error);
      });
  }
}
