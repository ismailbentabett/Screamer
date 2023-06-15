import { Component } from '@angular/core';
import { take } from 'rxjs';
import { CommentService } from 'src/app/core/services/comment.service';
import { TrendingService } from 'src/app/core/services/trending.service';

@Component({
  selector: 'app-side-content',
  templateUrl: './side-content.component.html',
  styleUrls: ['./side-content.component.scss'],
})
export class SideContentComponent {
  user: any;

  post: any;
  commentCount: number = 0;
  constructor(
    private trendingService: TrendingService,
    private commentService: CommentService
  ) {}
  ngOnInit(): void {
    this.getTopPreformingPost();
    this.getTopPreformingUser();
  }
  getTopPreformingPost() {
    this.trendingService.getTopPreformingPost().subscribe({
      next: (post) => {
        console.log(post);
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

  getTopPreformingUser() {
    this.trendingService.getTopPreformingUser().subscribe({
      next: (user) => {
        console.log(user);
        this.user = user;
      },
    });
  }
}
