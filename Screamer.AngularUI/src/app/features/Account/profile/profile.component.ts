import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { BusyService } from 'src/app/core/services/busy.service';
import { ModalService } from 'src/app/core/services/modal.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent {
  user: any;
  currentUser: any;
  isOpen: boolean = false;
  public Predicate!: string;
  /**
   *
   */
  constructor(
    private userService: UserService,
    private busyService: BusyService,
    private route: ActivatedRoute,
    public modalService: ModalService

  ) {
    this.busyService.busy();
    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.currentUser = user;
          this.busyService.idle();
        },
      });
  }
  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.userService.getUserById(params['id']).subscribe({
        next: (user) => {
          this.user = user;
        },
      });
    });
  }

  openPopup(predicate : string) {
    this.modalService.openPopup();
    this.Predicate = predicate;
  }
}
