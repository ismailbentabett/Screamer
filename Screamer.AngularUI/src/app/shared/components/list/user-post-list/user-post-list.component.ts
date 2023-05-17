import { Component } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Pagination } from 'src/app/core/models/Pagination';
import { Post } from 'src/app/core/models/Post';
import { PostParams } from 'src/app/core/models/PostParams';
import { User } from 'src/app/core/models/User';
import { PostService } from 'src/app/core/services/post.service';
import { UserService } from 'src/app/core/services/user.service';

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
user! : User;
userId? : string;

constructor(private postService: PostService ,  private route : ActivatedRoute ,
  private userService : UserService
  ) {

//get id from pqrqms


this.next = '<svg class="h-5 w-5" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true"><path fill-rule="evenodd" d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z" clip-rule="evenodd" /></svg>'
}

ngOnInit(): void {
  // this.members$ = this.memberService.getMembers();

  this.userService.getUserById(
    this.route.snapshot.paramMap.get('id') as string
  ).subscribe({
    next: (user) => {
      this.user = user;
    },
  });

  this.route.params.subscribe((params: any) => {
    this.userId = params['id'];
    this.postParams = this.postService.getPostParams(this.userId as string);
    this.loadPosts();
  });}
loadPosts() {
  if (this.postParams) {
    this.postService.setPostParams(this.postParams);
    this.postService.getPostsByUserId(this.postParams).subscribe({
      next: response => {
        if (response.result && response.pagination) {
          this.posts = response.result;
          this.pagination = response.pagination;
        }
      }
    })
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
}
