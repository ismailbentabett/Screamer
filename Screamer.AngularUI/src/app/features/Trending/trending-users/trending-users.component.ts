import { Component } from '@angular/core';
import { take } from 'rxjs';
import { Pagination } from 'src/app/core/models/Pagination';
import { User } from 'src/app/core/models/User';
import { UserParams } from 'src/app/core/models/userParams';
import { TrendingService } from 'src/app/core/services/trending.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-trending-users',
  templateUrl: './trending-users.component.html',
  styleUrls: ['./trending-users.component.scss'],
})
export class TrendingUsersComponent {
  users: User[] | undefined;
  predicate = 'liked';
  pageNumber = 1;
  pageSize = 10;
  pagination: Pagination | undefined;
  userParams: UserParams | undefined;
  next: string;
  currentUser: any;

  constructor(
    private trendingService: TrendingService,
    private userService: UserService
  ) {
    this.userParams = this.trendingService.getTopPreformingUsersParams();
    this.next =
      '<svg class="h-5 w-5" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true"><path fill-rule="evenodd" d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z" clip-rule="evenodd" /></svg>';
  }

  ngOnInit(): void {
    // this.members$ = this.memberService.getMembers();
    this.loadUsers();
  }
  loadUsers() {
    if (this.userParams) {
      this.trendingService.setTopPreformingUsersParams(this.userParams);
      this.trendingService.getTopPreformingUsers(this.userParams).subscribe({
        next: (response) => {
          if (response.result && response.pagination) {
            this.userService
              .getCurrentUserData()
              .pipe(take(1))
              .subscribe({
                next: (user: any) => {
                  this.currentUser = user;
                  this.users = response.result;
                  this.users = this.users!.filter(
                    (x: any) => x.id !== this.currentUser.id
                  );

                  this.pagination = response.pagination;
                },
              });
          }
        },
      });
    }
  }

  pageChanged(event: any) {
    if (this.userParams && this.userParams?.pageNumber !== event.page) {
      this.userParams.pageNumber = event.page;
      this.trendingService.setTopPreformingUsersParams(this.userParams);
      this.loadUsers();
    }
  }
}
