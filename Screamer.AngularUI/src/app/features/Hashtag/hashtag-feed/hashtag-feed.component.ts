import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { HashtagPostParams } from 'src/app/core/models/HashtagPostParams';
import { Pagination } from 'src/app/core/models/Pagination';
import { Post } from 'src/app/core/models/Post';
import { PostParams } from 'src/app/core/models/PostParams';
import { User } from 'src/app/core/models/User';
import { BusyService } from 'src/app/core/services/busy.service';
import { PostService } from 'src/app/core/services/post.service';
import { TrendingService } from 'src/app/core/services/trending.service';
import { UserService } from 'src/app/core/services/user.service';
@Component({
  selector: 'app-hashtag-feed',
  templateUrl: './hashtag-feed.component.html',
  styleUrls: ['./hashtag-feed.component.scss'],
})
export class HashtagFeedComponent {
  posts: Post[] | undefined;
  predicate = 'liked';
  pageNumber = 1;
  pageSize = 5;
  pagination: Pagination | undefined;
  postParams: HashtagPostParams | undefined;
  next: string | undefined;
  user!: User;
  userId?: string;
  hashtag: any;

  constructor(
    private trendingService: TrendingService,
    private route: ActivatedRoute,
    private userService: UserService,
    private busyService: BusyService
  ) {
    //get id from pqrqms

    this.next =
      '<svg class="h-5 w-5" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true"><path fill-rule="evenodd" d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z" clip-rule="evenodd" /></svg>';
  }

  ngOnInit(): void {
    this.hashtag = this.route.snapshot.paramMap.get('hashtag');

    // this.members$ = this.memberService.getMembers();

    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.user = user;
          this.postParams = this.trendingService.getPostsByHashtagParams(
            user.id as string,
            this.pageSize,
            this.pageNumber,
            this.hashtag
          );
          this.loadPosts();
        },
      });
  }
  loadPosts() {
    if (this.postParams) {
      this.trendingService.setPostsByHashtagParams(this.postParams);

      this.trendingService.getPostsByHashtag(this.postParams).subscribe({
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

      this.trendingService.setPostsByHashtagParams(this.postParams);
      this.loadPosts();
    }
  }
  loadMorePosts() {
    if (this.pagination) {
      this.postParams!.pageNumber++;
      this.trendingService.getPostsByHashtag(this.postParams!).subscribe({
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
