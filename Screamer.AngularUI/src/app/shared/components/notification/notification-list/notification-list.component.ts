import { Component, Input } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { take } from 'rxjs';
import { NotificationParams } from 'src/app/core/models/NotificationParams';
import { NotificationService } from 'src/app/core/services/notification.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-notification-list',
  templateUrl: './notification-list.component.html',
  styleUrls: ['./notification-list.component.scss'],
})
export class NotificationListComponent {
  Notifications: any[] = [];
  notificationPageNumber = 1;
  notificationPageSize = 2;

  notificationParams: NotificationParams | undefined;
  replyParams: NotificationParams | undefined;
  userId?: string;

  finalform: any;

  replyInput: boolean = false;
  @Input() shouldShowNotification!: boolean;
  constructor(
    private userService: UserService,
    private Notificationservice: NotificationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.notificationParams =
            this.Notificationservice.getnotificationParams(
              'CreatedAt',
              this.notificationPageNumber,
              this.notificationPageSize,
              user?.id
            );
          this.loadNotifications();
        },
      });
  }

  loadNotifications() {
    if (this.notificationParams) {
      this.Notificationservice.getnotificationsById(
        this.notificationParams
      ).subscribe((response) => {
        if (response.result && response.pagination) {
          response.result.forEach((element: any) => {
            this.userService.getUserById(element?.senderId).subscribe({
              next: (user) => {
                this.Notifications.push({
                  ...element,
                  user: user,
                });

                console.log(this.Notifications);
              },
            });
          });
        }
      });
    }
  }

  showMoreNotifications() {
    if (this.Notifications && this.notificationParams) {
      this.notificationParams.pageNumber++;
      this.Notificationservice.getnotificationsById(
        this.notificationParams
      ).subscribe((response) => {
        if (response.result && response.pagination) {
          this.Notifications = this.Notifications!.concat(response.result);
        }
      });
    }
  }
}
