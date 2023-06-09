import { Component } from '@angular/core';
import { take } from 'rxjs';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
})
export class AuthComponent {
  currentUser: any = null;
  /**
   *
   */
  constructor(
    private userService: UserService,
    private authService: AuthenticationService
  ) {
    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.currentUser = user;
          console.log(user)
        },
      });
  }

  sendVerificationEmail(email: string) {
    console.log(
      email
    )
    this.authService.sendVerificationEmail({
      email: email,
    });
  }
}
