import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { map, take } from 'rxjs';
import { environment } from 'src/environments/environment';
import { getPaginatedResult, getPaginationHeaders } from '../Helpers/paginationHelper';
import { PostParams } from '../models/PostParams';
import { Post } from '../models/Post';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  baseUrl = environment.baseWebApiUrl;
  PostParams: PostParams | undefined;

  constructor(
    private http: HttpClient,
    private authService: AuthenticationService
  ) {


  }

  getPostParams(userId : string , pageSize : number ,
    pageNumber : number
    ) {
    this.PostParams = new PostParams();
    this.PostParams.orderBy = 'CreatedAt';
    this.PostParams.pageNumber =
        pageNumber  ;
    this.PostParams.pageSize =
        pageSize
    ;
    this.PostParams.userId = userId;

    return this.PostParams;
  }

  setPostParams(params: PostParams) {
    this.PostParams = params;
  }

  resetPostParams(user : User) {
    if (user) {
      return this.PostParams;
    }
    return;
  }

  getPosts( postParams : PostParams) {
    let params = getPaginationHeaders(
      postParams.orderBy.toString(),
      postParams.userId.toString(),

      postParams.pageNumber,
      postParams.pageSize
    );

    return getPaginatedResult<Post[]>(
      this.baseUrl + 'Post',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );  }

  getPost(id: number) {
    return this.http.get(this.baseUrl + 'Post/' + id);
  }

  createPost(post: any) {
    return this.http.post(this.baseUrl + 'Post', post);
  }

  updatePost(post: any) {
    return this.http.put(this.baseUrl + 'Post', post);
  }

  deletePost(id: number) {
    return this.http.delete(this.baseUrl + 'Post/' + id);
  }

  getPostsByUserId( postParams : PostParams) {
    let params = getPaginationHeaders(
      postParams.orderBy.toString(),
      postParams.userId.toString(),

      postParams.pageNumber,
      postParams.pageSize
    );

    return getPaginatedResult<Post[]>(
      this.baseUrl + 'Post/user',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );  }
}
