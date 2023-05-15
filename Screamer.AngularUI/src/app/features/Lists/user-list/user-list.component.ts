import { Component } from '@angular/core';
import { Pagination } from 'src/app/core/models/Pagination';
import { User } from 'src/app/core/models/User';
import { UserParams } from 'src/app/core/models/userParams';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent {
  users: User[] | undefined;
  predicate = 'liked';
  pageNumber = 1;
  pageSize = 5;
  pagination: Pagination | undefined;
  userParams: UserParams | undefined;


  constructor(private userService: UserService) {
    this.userParams = this.userService.getUserParams();
  }

  ngOnInit(): void {
    // this.members$ = this.memberService.getMembers();
    this.loadUsers();
  }
  loadUsers() {
    if (this.userParams) {
      this.userService.setUserParams(this.userParams);
      this.userService.getUsers(this.userParams).subscribe({
        next: response => {
          if (response.result && response.pagination) {
            this.users = response.result;
            this.pagination = response.pagination;
          }
        }
      })
    }
  }

  resetFilters() {
    this.userParams = this.userService.resetUserParams();
    this.loadUsers();
  }

  pageChanged(event: any) {
    if (this.userParams && this.userParams?.pageNumber !== event.page) {
      this.userParams.pageNumber = event.page;
      this.userService.setUserParams(this.userParams);
      this.loadUsers();
    }
  }
}
