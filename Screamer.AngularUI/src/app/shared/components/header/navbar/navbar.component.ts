import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {

  constructor(
    public authService: AuthenticationService,
    private router: Router
  ) {}


  logout() {
    this.authService.logout();
    this.router.navigateByUrl('/');
  }
}
