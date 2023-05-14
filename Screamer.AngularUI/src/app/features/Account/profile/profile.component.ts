import { Component } from '@angular/core';
import { take } from 'rxjs';
import { BusyService } from 'src/app/core/services/busy.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent {
  user: any;

  /**
   *
   */
  constructor(private userService: UserService ,  private busyService : BusyService) {
    this.busyService.busy()
    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.user = user;
          this.busyService.idle()
        },
      });
  }
  ngOnInit(): void {}
}
