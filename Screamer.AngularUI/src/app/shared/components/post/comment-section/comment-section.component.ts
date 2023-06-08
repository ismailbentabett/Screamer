import { Component, Input } from '@angular/core';
import { take } from 'rxjs';
import { CommentParams } from 'src/app/core/models/CommentParams';
import { User } from 'src/app/core/models/User';
import { CommentService } from 'src/app/core/services/comment.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-comment-section',
  templateUrl: './comment-section.component.html',
  styleUrls: ['./comment-section.component.scss'],
})
export class CommentSectionComponent {
  @Input() post: any;
  comments: any[] | undefined;
  replies: any[] | undefined;
  commentPageNumber = 1;
  commentPageSize = 2;
  replyPageNumber = 1;
  replyPageSize = 2;
  commentParams: CommentParams | undefined;
  replyParams: CommentParams | undefined;
  user!: User;
  userId?: string;

  finalform: any;

  replyInput: boolean = false;
  constructor(
    private userService: UserService,
    private commentService: CommentService
  ) {}

  ngOnInit(): void {
    this.commentParams = this.commentService.getCommentParams(
      this.post.id,
      this.commentPageSize,
      this.commentPageNumber,
      null
    );
    this.loadComments();

    this.replyParams = this.commentService.getReplyParams(
      this.post.id,
      this.replyPageSize,
      this.replyPageNumber,
      null
    );
  }

  togglereplyInput() {
    this.replyInput = !this.replyInput;
  }
  loadComments() {
    if (this.commentParams) {
      this.commentService
        .getCommentsByPostId(this.commentParams)
        .subscribe((response) => {
          if (response.result && response.pagination) {
            this.comments = response.result;
            //add the replies
            this.comments!.forEach((comment) => {
              this.loadReplies(comment.id);
            });
          }
        });
    }
  }

  loadReplies(commentId: number) {
    if (this.replyParams) {
      this.replyParams.parentCommentId = commentId;
      this.replyParams.commentId = commentId;

      this.commentService
        .getRepliesByCommentId(this.replyParams)
        .subscribe((response) => {
          if (response.result && response.pagination) {
            this.replies = response.result;
            this.comments?.forEach((comment) => {
              this.replies?.forEach((reply) => {
                if (comment.id == reply.parentCommentId) {
                  comment.replies.push(reply);
                }
              });
            });
          }
        });
    }
  }

  showMoreComments() {
    if (this.comments && this.commentParams) {
      this.commentParams.pageNumber++;
      this.commentService
        .getCommentsByPostId(this.commentParams)
        .subscribe((response) => {
          if (response.result && response.pagination) {
            this.comments = this.comments!.concat(response.result);
            response.result!.forEach((comment: any) => {
              this.loadReplies(comment.id);
            });
            this.comments?.forEach((comment) => {
              this.replies?.forEach((reply) => {
                if (comment.id == reply.parentCommentId) {
                  comment.replies.push(reply);
                }
              });
            });
          }
        });
    }
  }

  showMoreReplies(commentId: number) {
    if (this.replies && this.replyParams) {
      this.replyParams.pageNumber++;
      this.replyParams.parentCommentId = commentId;
      this.replyParams.commentId = commentId;

      this.commentService
        .getRepliesByCommentId(this.replyParams)
        .subscribe((response) => {
          if (response.result && response.pagination) {
            this.comments?.forEach((comment) => {
              response.result?.forEach((reply: any) => {
                if (comment.id == reply.parentCommentId) {
                  comment.replies.push(reply);
                }
              });
            });
          }
        });
    }
  }
}
