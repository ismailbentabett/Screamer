import { Component, Input } from '@angular/core';
import { take } from 'rxjs';
import { FollowParams } from 'src/app/core/models/FollowParams';
import { Pagination } from 'src/app/core/models/Pagination';
import { User } from 'src/app/core/models/User';
import { CommentService } from 'src/app/core/services/comment.service';
import { TrendingService } from 'src/app/core/services/trending.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-side-content',
  templateUrl: './side-content.component.html',
  styleUrls: ['./side-content.component.scss'],
})
export class SideContentComponent {
  sourceUser!: User;
  followeParams!: any;
  followings!: any;
  followers!: any;
  user: any;

  post: any;
  commentCount: number = 0;

  followersPredicate = 'followers';
  followingPredicate = 'following';
  pageNumber = 1;
  pageSize = 5;
  followersPagination: Pagination | undefined;

  followingsPagination: Pagination | undefined;
  isUserInMyFollowers: boolean = false;
  isUserInMyFollowings: boolean = false;
  targetUser: any;

  constructor(
    private trendingService: TrendingService,
    private commentService: CommentService,
    private userService: UserService
  ) {}
  ngOnInit(): void {
    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.sourceUser = user;

          this.getTopPreformingUser(user.id);
        },
      });
    this.getTopPreformingPost();
  }
  getTopPreformingPost() {
    this.trendingService.getTopPreformingPost().subscribe({
      next: (post) => {
        this.post = post;

        this.commentService
          .getCommentCount(this.post.id)
          .pipe(take(1))
          .subscribe({
            next: (count: any) => {
              this.commentCount = count.result;
            },
          });
      },
    });
  }

  getTopPreformingUser(currentUserId: any) {
    this.trendingService.getTopPreformingUser(currentUserId).subscribe({
      next: (user) => {
        this.user = user;
        this.targetUser = user;
        this.loadFollowers();
        this.loadFollowings();
      },
    });
  }

  follow(targetUser: User) {
    this.userService
      .addFollow(this.sourceUser!.id as any, targetUser!.id as any)
      .subscribe({
        next: () => {
          this.loadFollowers();
          this.loadFollowings();
        },
      });
  }

  unfollow(targetUser: User) {
    this.userService
      .removeFollow(this.sourceUser!.id as any, targetUser!.id as any)
      .subscribe({
        next: () => {
          this.loadFollowers();
          this.loadFollowings();
        },
      });
  }

  loadFollowers() {
    let parameters: FollowParams = {
      predicate: 'followers',
      pageNumber: this.pageNumber,
      pageSize: this.pageSize,
      userId: this.sourceUser.id as any,
    };

    this.userService.getFollows(parameters).subscribe({
      next: (response) => {
        this.followers = response.result;
        this.followersPagination = response.pagination;
        this.isUserInMyFollowers = this.followers.some(
          (x: any) => x.userId === this.targetUser.id
        );
      },
    });
  }
  loadFollowings() {
    let parameters: FollowParams = {
      predicate: this.followingPredicate,
      pageNumber: this.pageNumber,
      pageSize: this.pageSize,
      userId: this.sourceUser.id as any,
    };

    this.userService.getFollows(parameters).subscribe({
      next: (response) => {
        this.followings = response.result;
        this.followingsPagination = response.pagination;
        this.isUserInMyFollowings = this.followings.some(
          (x: any) => x.userId === this.targetUser.id
        );
      },
    });
  }
}
