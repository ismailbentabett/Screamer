import { Injectable } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { take } from 'rxjs';
import { User } from '../models/User';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ReactionService {
  user!: User;
  baseUrl = environment.baseWebApiUrl;

  constructor(
    private http: HttpClient,
    private authService: AuthenticationService
  ) {
    this.authService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => {
        if (user) {
          this.user = user;
        }
      },
    });
  }

  addPostReaction(postId: number, reactionType: string) {
    return this.http.post(
      this.baseUrl +
        `Reaction/add-post-reaction?postId=${postId}&userId=${this.user.id}&reactionType=${reactionType}`,
      {}
    );
  }
  addCommentReaction(commentId: number, reactionType: string) {
    return this.http.post(
      this.baseUrl +
        `Reaction/add-comment-reaction?commentId=${commentId}&userId=${
          this.user.id
        }&reactionType=${reactionType}&isPost=${false}`,
      {}
    );
  }

  deletePostReaction(postId: number, reactionType: string, reactionId: number) {
    return this.http.delete(
      this.baseUrl +
        `Reaction/delete-reaction?postId=${postId}&userId=${
          this.user.id
        }&reactionType=${reactionType}&isPost=${true}&reactionId=${reactionId}`
    );
  }
  deleteCommentReaction(
    commentId: number,
    reactionType: string,
    reactionId: number
  ) {
    return this.http.delete(
      this.baseUrl +
        `Reaction/delete-reaction?commentId=${commentId}&userId=${
          this.user.id
        }&reactionType=${reactionType}&isPost=${false}&reactionId=${reactionId}`
    );
  }

  updatePostReaction(postId: number, reactionType: string, reactionId: number) {
    return this.http.put(
      this.baseUrl +
        `Reaction/update-reaction?postId=${postId}&userId=${
          this.user.id
        }&reactionType=${reactionType}&isPost=${true}&reactionId=${reactionId}
      `,
      {}
    );
  }

  updateCommentReaction(
    commentId: number,
    reactionType: string,
    reactionId: number
  ) {
    return this.http.put(
      this.baseUrl +
        `Reaction/update-reaction?commentId=${commentId}&userId=${
          this.user.id
        }&reactionType=${reactionType}&isPost=${true}&reactionId=${reactionId}
        `,
      {}
    );
  }
}
