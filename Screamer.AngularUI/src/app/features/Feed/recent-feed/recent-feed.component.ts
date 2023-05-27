import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { Pagination } from 'src/app/core/models/Pagination';
import { Post } from 'src/app/core/models/Post';
import { PostParams } from 'src/app/core/models/PostParams';
import { User } from 'src/app/core/models/User';
import { BusyService } from 'src/app/core/services/busy.service';
import { PostService } from 'src/app/core/services/post.service';
import { UserService } from 'src/app/core/services/user.service';
@Component({
  selector: 'app-recent-feed',
  templateUrl: './recent-feed.component.html',
  styleUrls: ['./recent-feed.component.scss'],
})
export class RecentFeedComponent {
  posts: Post[] | undefined;
  predicate = 'liked';
  pageNumber = 1;
  pageSize = 5;
  pagination: Pagination | undefined;
  postParams: PostParams | undefined;
  next: string | undefined;
  user!: User;
  userId?: string;

  constructor(
    private postService: PostService,
    private route: ActivatedRoute,
    private userService: UserService,
    private busyService: BusyService
  ) {
    //get id from pqrqms

    this.next =
      '<svg class="h-5 w-5" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true"><path fill-rule="evenodd" d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z" clip-rule="evenodd" /></svg>';
  }

  ngOnInit(): void {
    // this.members$ = this.memberService.getMembers();

    this.busyService.busy();
    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.user = user;
          this.postParams = this.postService.getPostParams(
            user.id as string,
            this.pageSize,
            this.pageNumber
          );
          this.loadPosts();
          this.busyService.idle();
        },
      });
  }
  loadPosts() {
    if (this.postParams) {
      this.postService.setPostParams(this.postParams);
      this.postService.getMostRecentPosts(this.postParams).subscribe({
        next: (response) => {
          if (response.result && response.pagination) {
            this.posts = response.result;
            this.pagination = response.pagination;
          }
        },
      });
    }
  }

  resetFilters() {
    this.postParams = this.postService.resetPostParams(this.user);
    this.loadPosts();
  }

  pageChanged(event: any) {
    if (this.postParams && this.postParams?.pageNumber !== event.page) {
      this.postParams.pageNumber = event.page;
      this.postService.setPostParams(this.postParams);
      this.loadPosts();
    }
  }
  loadMorePosts() {
    if (this.pagination) {
      this.postParams!.pageNumber++;
      this.postService.getMostRecentPosts(this.postParams!).subscribe({
        next: (response) => {
          if (response.result && response.pagination) {
            this.posts = this.posts!.concat(response.result);
            this.pagination = response.pagination;
          }
        },
      });
    }
  }
}
