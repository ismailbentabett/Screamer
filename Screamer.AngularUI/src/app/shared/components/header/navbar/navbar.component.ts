import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  shouldShowLoginButton?: boolean;
  shouldShowSignUpButton?: boolean;
  constructor(
    public authService: AuthenticationService,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.router.events.subscribe(() => {
      this.shouldShowLoginButton = this.router.url !== '/auth/login';
      this.shouldShowSignUpButton = this.router.url !== '/auth/signup';
  });

  }

  logout() {
    this.authService.logout();
    this.router.navigateByUrl('/');
  }
}
