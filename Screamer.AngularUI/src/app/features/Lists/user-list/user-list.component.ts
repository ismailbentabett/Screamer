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
next : string ;

  constructor(private userService: UserService) {
    this.userParams = this.userService.getUserParams();
this.next = '<svg class="h-5 w-5" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true"><path fill-rule="evenodd" d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z" clip-rule="evenodd" /></svg>'
  }

  ngOnInit(): void {
    // this.members$ = this.memberService.getMembers();
    this.loadUsers();
  }
  loadUsers() {
    console.log("haha")
    console.log(this.userParams)
    if (this.userParams) {
      this.userService.setUserParams(this.userParams);
      this.userService.getUsers(this.userParams).subscribe({
        next: response => {
          console.log(response)
          if (response.result && response.pagination) {
            this.users = response.result;
            console.log(this.users)
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
