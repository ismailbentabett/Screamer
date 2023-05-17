import { Component } from '@angular/core';
import { Pagination } from 'src/app/core/models/Pagination';
import { Post } from 'src/app/core/models/Post';
import { PostParams } from 'src/app/core/models/PostParams';
import { PostService } from 'src/app/core/services/post.service';

@Component({
  selector: 'app-user-post-list',
  templateUrl: './user-post-list.component.html',
  styleUrls: ['./user-post-list.component.scss']
})
export class UserPostListComponent {
  posts: Post[] | undefined;
  predicate = 'liked';
  pageNumber = 1;
  pageSize = 5;
  pagination: Pagination | undefined;
  postParams: PostParams | undefined;
next : string | undefined ;

constructor(private postService: PostService) {
  this.postParams = this.postService.getPostParams();
this.next = '<svg class="h-5 w-5" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true"><path fill-rule="evenodd" d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z" clip-rule="evenodd" /></svg>'
}

ngOnInit(): void {
  // this.members$ = this.memberService.getMembers();
  this.loadPosts();
}
loadPosts() {
  if (this.postParams) {
    this.postService.setPostParams(this.postParams);
    this.postService.getPostsByUserId(this.postParams).subscribe({
      next: response => {
        console.log("response")
        if (response.result && response.pagination) {
          this.posts = response.result;
          console.log(this.posts)
          this.pagination = response.pagination;
        }
      }
    })
  }
}

resetFilters() {
  this.postParams = this.postService.resetPostParams();
  this.loadPosts();
}

pageChanged(event: any) {
  if (this.postParams && this.postParams?.pageNumber !== event.page) {
    this.postParams.pageNumber = event.page;
    this.postService.setPostParams(this.postParams);
    this.loadPosts();
  }
}
}
