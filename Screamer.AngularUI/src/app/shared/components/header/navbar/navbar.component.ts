import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs';
import { User } from 'src/app/core/models/User';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  user: User | null = null;

  constructor(
    public authService: AuthenticationService,
    private router: Router
  ) {
    this.authService.currentUser$
      .pipe()
      .subscribe((user) => (this.user = user));



  }


  //oninit
  ngOnInit(): void {

  }
  logout() {
    this.authService.logout();
    this.router.navigateByUrl('/');
  }
}
