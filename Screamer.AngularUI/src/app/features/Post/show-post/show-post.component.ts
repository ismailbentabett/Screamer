import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Post } from 'src/app/core/models/Post';
import { PostService } from 'src/app/core/services/post.service';

@Component({
  selector: 'app-show-post',
  templateUrl: './show-post.component.html',
  styleUrls: ['./show-post.component.scss'],
})
export class ShowPostComponent {
  post!: Post;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private postService: PostService
  ) {
    router.events.subscribe((val) => {
      this.route.paramMap.subscribe(async (params) => {
        let postId = params.get('postId');
        this.postService
          .getPost(parseInt(postId as string))
          .subscribe((post) => {
            this.post = post as Post;
          });
      });
    });
  }
}
