import { Component, Input } from '@angular/core';
import { FollowParams } from 'src/app/core/models/FollowParams';
import { Pagination } from 'src/app/core/models/Pagination';
import { ModalService } from 'src/app/core/services/modal.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-follow-modal',
  templateUrl: './follow-modal.component.html',
  styleUrls: ['./follow-modal.component.scss'],
})
export class FollowModalComponent {
  @Input() Predicate!: string;

  pageNumber = 1;
  pageSize = 5;
  followersPagination: any;
  followingsPagination: any;
  @Input() user: any;
  followers: any[] | undefined;
  followings: any[] | undefined;

  constructor(
    public modalService: ModalService,
    private userService: UserService
  ) {}
  openPopup() {
    this.modalService.openPopup();
  }

  closePopup() {
    this.modalService.closePopup();
  }


  ngOnInit(): void {
     if(this.Predicate
          == "followers"
      ) {
          this.loadFollowers()
      }
     if(this.Predicate
          == "following"
      ) {
          this.loadFollowings()
      }


    }

  loadFollowers() {
    let parameters: FollowParams = {
      predicate: this.Predicate,
      pageNumber: this.pageNumber,
      pageSize: this.pageSize,
      userId: this.user.id as any,
    };

    console.log(parameters);
    this.userService.getFollows(parameters).subscribe({
      next: (response) => {
        console.log(response);
        this.followers = response.result;
        console.log(
          response
        )
        this.followersPagination = response.pagination;
      },
    });
  }
  loadFollowings() {
    let parameters: FollowParams = {
      predicate: this.Predicate,
      pageNumber: this.pageNumber,
      pageSize: this.pageSize,
      userId: this.user.id as any,
    };

    this.userService.getFollows(parameters).subscribe({
      next: (response) => {
        console.log(
          response
        )
        this.followings = response.result;
        this.followingsPagination = response.pagination;
      },
    });
  }
}
