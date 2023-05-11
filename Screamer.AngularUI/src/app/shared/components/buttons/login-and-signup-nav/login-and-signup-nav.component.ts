import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-and-signup-nav',
  templateUrl: './login-and-signup-nav.component.html',
  styleUrls: ['./login-and-signup-nav.component.scss'],
})
export class LoginAndSignupNavComponent {
  shouldShowLoginButton?: boolean;
  shouldShowSignUpButton?: boolean;
  constructor(
    private router: Router
  ) {}
  ngOnInit(): void {
    this.router.events.subscribe(() => {
      this.shouldShowLoginButton = this.router.url !== '/auth/login';
      this.shouldShowSignUpButton = this.router.url !== '/auth/signup';
    });
  }
}
