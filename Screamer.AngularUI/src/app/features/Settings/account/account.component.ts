import { Component } from '@angular/core';
import { take } from 'rxjs';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss'],
})
export class AccountComponent {
  currentUser: any = null;
  constructor(
    public authService: AuthenticationService,
    public userService: UserService
  ) {
    this.userService
    .getCurrentUserData()
    .pipe(take(1))
    .subscribe({
      next: (user: any) => {
        this.currentUser = user;
      },
    });
  }

  openDeleteMyAccountPopup() {
    this.userService.openDeleteMyAccountPopup();
  }
}
