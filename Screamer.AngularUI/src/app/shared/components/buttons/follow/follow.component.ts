import { Component, Input } from '@angular/core';
import { find, take } from 'rxjs';
import { Follow } from 'src/app/core/models/Follow';
import { FollowParams } from 'src/app/core/models/FollowParams';
import { PaginatedResult, Pagination } from 'src/app/core/models/Pagination';
import { User } from 'src/app/core/models/User';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-follow',
  templateUrl: './follow.component.html',
  styleUrls: ['./follow.component.scss'],
})
export class FollowComponent {
  @Input() targetUser!: User;
  sourceUser!: User;
  followeParams!: any;
  followings!: any;
  followers!: any;



  followersPredicate = 'followers';
  followingPredicate = 'following';
  pageNumber = 1;
  pageSize = 5;
  followersPagination: Pagination | undefined;

  followingsPagination: Pagination | undefined;
isUserInMyFollowers : boolean = false;
isUserInMyFollowings : boolean = false;


  constructor(private userService: UserService) {



  }

  follow() {
    this.userService
      .addFollow(this.sourceUser!.id as any, this.targetUser!.id as any)
      .subscribe({
        next: () => {
          this.loadFollowers();
          this.loadFollowings();
        },
      });
  }

  //ngoninit
  ngOnInit(): void {
    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.sourceUser = user;
          this.loadFollowers();
          this.loadFollowings();
        },
      });



    console.log(
      'this.followersPagination',
      this.followersPagination,
      'this.followingsPagination',
      this.followingsPagination

    )
    console.log(
      'this.followers',
      this.followers,
      'this.followings',
      this.followings
    )



  }

  unfollow() {

    this.userService
      .removeFollow(this.sourceUser!.id as any, this.targetUser!.id as any)
      .subscribe({
        next: () => {
          this.loadFollowers();
          this.loadFollowings();
        },
      });
  }


  loadFollowers() {
    let parameters : FollowParams = {
      predicate: "followers",
      pageNumber: this.pageNumber,
      pageSize: this.pageSize,
        userId :     this.sourceUser.id as any
    }

    console.log(
      parameters
    )
    this.userService.getFollows(parameters).subscribe({
      next: response => {
        console.log(response)
        this.followers = response.result ;
        this.followersPagination = response.pagination;
        this.isUserInMyFollowers = this.followers.some
        ((x : any) => x.userId === this.targetUser.id);
      }
    })
  }
  loadFollowings() {

    let parameters : FollowParams = {
      predicate: this.followingPredicate,
      pageNumber: this.pageNumber,
      pageSize: this.pageSize,
        userId :     this.sourceUser.id as any
    }

    this.userService.getFollows(parameters).subscribe({
      next: response => {
        this.followings = response.result;
        this.followingsPagination = response.pagination;
        this.isUserInMyFollowings =
        this.followings.some((x : any) => x.userId === this.targetUser.id);
      }
    })
  }

  pageChanged(event: any) {
    if (this.pageNumber !== event.page) {
      this.pageNumber = event.page;
      this.loadFollowers();
      this.loadFollowings();
    }
  }


}
