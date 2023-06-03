import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs';
import { User } from 'src/app/core/models/User';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { UserService } from 'src/app/core/services/user.service';
import {
  trigger,
  state,
  style,
  transition,
  animate,
} from '@angular/animations';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
  animations: [
    trigger('dropdownAnimation', [
      state(
        'open',
        style({
          transform: 'opacity-100 scale-100',
          opacity: 1,
        })
      ),
      state(
        'closed',
        style({
          transform: 'opacity-0 scale-95',
          opacity: 0,
        })
      ),
      transition('closed => open', animate('100ms ease-out')),
      transition('open => closed', animate('75ms ease-in')),
    ]),
  ],
})
export class NavbarComponent {
  user: User | null = null;
  userData!: User;

  constructor(
    public authService: AuthenticationService,
    private router: Router,
    private userService: UserService,
    private route: ActivatedRoute
  ) {
    this.authService.currentUser$.pipe().subscribe((user) => {
      this.user = user;

      console.log(this.user!.id);
      this.userService
        .getUserById(user!.id as any)
        .pipe()
        .subscribe((data) => {
          if (data) {
            this.userData = data;
          } else {
            this.logout();
          }
        });
    });
  }

  LinkStyle(route: string): string {
    const isActive =
      this.router.isActive(route, false) || this.router.isActive(route, true);

    return isActive
      ? 'bg-gray-100 text-gray-900 rounded-md py-2 px-3 inline-flex items-center text-sm font-medium'
      : 'text-gray-900 hover:bg-gray-50 hover:text-gray-900 rounded-md py-2 px-3 inline-flex items-center text-sm font-medium';
  }

  LinkStyle2(route: string): string {
    const isActive =
      this.router.isActive(route, false) || this.router.isActive(route, true);

    return isActive
      ? 'bg-gray-100 text-gray-900 block rounded-md py-2 px-3 text-base font-medium'
      : 'bg-white text-gray-500 block rounded-md py-2 px-3 text-base font-medium';
  }
  IconsStyle(route: string): string {
    const isActive =
      this.router.isActive(route, false) || this.router.isActive(route, true);

    return isActive
      ? 'ml-auto flex-shrink-0 bg-white rounded-full p-1 text-gray-900 hover:text-gray-900 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-dodger-blue-500'
      : 'ml-auto flex-shrink-0 bg-white rounded-full p-1 text-gray-400 hover:text-gray-500 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-dodger-blue-500';
  }
  MobileLinkStyle(route: string) {
    const isActive =
      this.router.isActive(route, false) || this.router.isActive(route, true);

    return isActive
      ? 'block rounded-md py-2 px-3 text-base font-medium text-gray-500 bg-gray-50 hover:text-gray-900'
      : 'block rounded-md py-2 px-3 text-base font-medium text-gray-500 hover:bg-gray-50 hover:text-gray-900';
  }

  dropDownLintStyle(route: string) {
    const isActive =
      this.router.isActive(route, false) || this.router.isActive(route, true);

    return isActive
      ? 'block py-2 px-4 text-sm text-gray-700 cursor-pointer bg-gray-100 hover:bg-gray-100'
      : 'block py-2 px-4 text-sm text-gray-700 cursor-pointer hover:bg-gray-100';
  }

  //oninit
  ngOnInit(): void {}
  logout() {
    this.authService.logout();
    this.router.navigateByUrl('/');
  }
  isOpen = false;

  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }
}
