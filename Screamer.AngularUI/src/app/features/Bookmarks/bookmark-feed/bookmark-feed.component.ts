import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { Pagination } from 'src/app/core/models/Pagination';
import { Post } from 'src/app/core/models/Post';
import { PostParams } from 'src/app/core/models/PostParams';
import { User } from 'src/app/core/models/User';
import { BookmarkService } from 'src/app/core/services/bookmark.service';
import { BusyService } from 'src/app/core/services/busy.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-bookmark-feed',
  templateUrl: './bookmark-feed.component.html',
  styleUrls: ['./bookmark-feed.component.scss'],
})
export class BookmarkFeedComponent {
  posts: Post[] | undefined;
  predicate = 'liked';
  pageNumber = 1;
  pageSize = 5;
  pagination: Pagination | undefined;
  postParams: PostParams | undefined;
  next: string | undefined;
  user!: any;
  userId?: string;

  constructor(
    private bookMarkedService: BookmarkService,
    private route: ActivatedRoute,
    private userService: UserService,
    private busyService: BusyService
  ) {
    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.user = user;
        },
      });
    this.next =
      '<svg class="h-5 w-5" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true"><path fill-rule="evenodd" d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z" clip-rule="evenodd" /></svg>';
  }

  ngOnInit(): void {
    // this.members$ = this.memberService.getMembers();

    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.user = user;
          this.postParams = this.bookMarkedService.getBookMarkedPostsParams(
            user.id as string,
            this.pageSize,
            this.pageNumber
          );
          this.loadPosts();
        },
      });
  }
  loadPosts() {
    if (this.postParams) {
      this.bookMarkedService.setBookMarkedPostsParams(this.postParams);
      this.bookMarkedService.getBookMarkedPosts(this.postParams).subscribe({
        next: (response) => {
          if (response.result && response.pagination) {
            this.posts = response.result;
            this.pagination = response.pagination;
          }
        },
      });
    }
  }

  pageChanged(event: any) {
    if (this.postParams && this.postParams?.pageNumber !== event.page) {
      this.postParams.pageNumber = event.page;
      this.bookMarkedService.getBookMarkedPostsParams(
        this.user.id as string,
        this.pageSize,
        this.pageNumber
      );
      this.loadPosts();
    }
  }
  loadMorePosts() {
    if (this.pagination) {
      this.postParams!.pageNumber++;
      this.bookMarkedService.getBookMarkedPosts(this.postParams!).subscribe({
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
