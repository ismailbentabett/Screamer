import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs';
import { User } from 'src/app/core/models/User';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { UserService } from 'src/app/core/services/user.service';
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
  animations: [
    trigger('dropdownAnimation', [
      state('open', style({
        transform: 'opacity-100 scale-100',
        opacity: 1,
      })),
      state('closed', style({
        transform: 'opacity-0 scale-95',
        opacity: 0,
      })),
      transition('closed => open', animate('100ms ease-out')),
      transition('open => closed', animate('75ms ease-in')),
    ]),
  ],
})
export class NavbarComponent {
  user: User | null = null;
  userData! : User

  constructor(
    public authService: AuthenticationService,
    private router: Router,
    private userService : UserService
  ) {
    this.authService.currentUser$
      .pipe()
      .subscribe((user) => (this.user = user));



  }


  //oninit
  ngOnInit(): void {
    this.userService.getUserById(
      this.user!.id
    ).pipe()
    .subscribe((data) => (this.userData = data));
  }
  logout() {
    this.authService.logout();
    this.router.navigateByUrl('/');
  }
  isOpen = false;

  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }
}
