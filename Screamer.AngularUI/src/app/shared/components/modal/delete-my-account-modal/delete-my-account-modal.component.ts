import { Component, Input } from '@angular/core';
import { take } from 'rxjs';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-delete-my-account-modal',
  templateUrl: './delete-my-account-modal.component.html',
  styleUrls: ['./delete-my-account-modal.component.scss'],
})
export class DeleteMyAccountModalComponent {
 @Input () currentUser: any = null;
  constructor(
    public authService: AuthenticationService,
    public userService: UserService
  ) {

  }

  closeDeleteMyAccountPopup() {
    this.userService.closeDeleteMyAccountPopup();
  }

  deleteMyAccount(id: string) {
    this.userService.deleteMyAccount(id).subscribe({
      next: () => {
        this.authService.logout();
      },
    });
  }
}
