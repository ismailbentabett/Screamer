import { Injectable } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { CommentParams } from '../models/CommentParams';
import {
  getCommentPaginationHeaders,
  getPaginatedResult,
  getPaginationHeaders,
} from '../Helpers/paginationHelper';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CommentService {
  baseUrl: string = environment.baseWebApiUrl;
  commentParams: CommentParams | undefined;
  repliesParams: CommentParams | undefined;

  constructor(
    private http: HttpClient,
    private authService: AuthenticationService
  ) {}

  getCommentParams(
    postId: number,
    pageSize: number,
    pageNumber: number,
    parentCommentId: number
  ) {
    this.commentParams = new CommentParams();
    this.commentParams.orderBy = 'CreatedAt';
    this.commentParams.pageNumber = pageNumber;
    this.commentParams.pageSize = pageSize;
    this.commentParams.postId = postId;
    this.commentParams.parentCommentId = parentCommentId;

    return this.commentParams;
  }

  setCommentParams(params: CommentParams) {
    this.commentParams = params;
  }

  getReplyParams(
    postId: number,
    pageSize: number,
    pageNumber: number,
    parentCommentId: number
  ) {
    this.repliesParams = new CommentParams();
    this.repliesParams.orderBy = 'CreatedAt';
    this.repliesParams.pageNumber = pageNumber;
    this.repliesParams.pageSize = pageSize;
    this.repliesParams.postId = postId;
    this.repliesParams.parentCommentId = parentCommentId;

    return this.repliesParams;
  }

  setReplyParams(params: CommentParams) {
    this.repliesParams = params;
  }

  createComment(comment: any) {
    return this.http.post(this.baseUrl + 'Post/add-comment', comment);
  }
  createReply(comment: any) {
    return this.http.post(this.baseUrl + 'Post/add-reply', comment);
  }

  getCommentsByPostId(commentParams: CommentParams) {
    let params = getCommentPaginationHeaders(
      commentParams.orderBy,
      commentParams.postId,
      commentParams.parentCommentId,
      commentParams.pageNumber,
      commentParams.pageSize
    );

    return getPaginatedResult<any[]>(
      this.baseUrl + 'Post/get-comments-by-post-id',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );
  }
  getRepliesByCommentId(commentParams: CommentParams) {
    let params = getCommentPaginationHeaders(
      commentParams.orderBy,
      commentParams.postId,
      commentParams.parentCommentId,
      commentParams.pageNumber,
      commentParams.pageSize
    );

    return getPaginatedResult<any[]>(
      this.baseUrl + 'Post/get-replies-by-comment-id',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );
  }
}
