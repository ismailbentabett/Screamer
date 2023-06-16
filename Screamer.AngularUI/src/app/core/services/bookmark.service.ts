import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PostParams } from '../models/PostParams';
import {
  getPaginatedResult,
  getPaginationHeaders,
} from '../Helpers/paginationHelper';
import { Post } from '../models/Post';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BookmarkService {
  baseUrl = environment.baseWebApiUrl;

  BookMarkedPosts: PostParams | undefined;

  constructor(private http: HttpClient) {}

  getBookMarks() {
    return this.http.get(this.baseUrl + 'BookMark');
  }

  AddBookMark(model: any) {
    return this.http.post(this.baseUrl + 'BookMark', model);
  }

  DeleteBookMark(model: any) {
    return this.http.delete(this.baseUrl + 'BookMark', model);
  }

  UpdateBookMark(model: any) {
    return this.http.put(this.baseUrl + 'BookMark', model);
  }

  IsBookMarked(model: any) {
    return this.http.get(
      this.baseUrl +
        `BookMark/is-bookmarked?UserId=${model.userId}&PostId=${model.postId}`
    );
  }

  getBookMarkedPosts(postParams: PostParams) {
    let params = getPaginationHeaders(
      postParams.orderBy.toString(),
      postParams.userId.toString(),

      postParams.pageNumber,
      postParams.pageSize
    );
    return getPaginatedResult<Post[]>(
      this.baseUrl + 'BookMark/bookmarked-posts',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );
  }
  getBookMarkedPostsParams(
    userId: string,
    pageSize: number,
    pageNumber: number
  ) {
    this.BookMarkedPosts = new PostParams();
    this.BookMarkedPosts.orderBy = 'CreatedAt';
    this.BookMarkedPosts.pageNumber = pageNumber;
    this.BookMarkedPosts.pageSize = pageSize;
    this.BookMarkedPosts.userId = userId;

    return this.BookMarkedPosts;
  }

  setBookMarkedPostsParams(params: PostParams) {
    this.BookMarkedPosts = params;
  }
}
