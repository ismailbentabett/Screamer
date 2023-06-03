import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { BehaviorSubject, map, take } from 'rxjs';
import { environment } from 'src/environments/environment';
import {
  getPaginatedResult,
  getPaginationHeaders,
} from '../Helpers/paginationHelper';
import { PostParams } from '../models/PostParams';
import { Post } from '../models/Post';
import { User } from '../models/User';
import { RecommendationParams } from '../models/RecommendationParams';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  baseUrl = environment.baseWebApiUrl;
  PostParams: PostParams | undefined;

  private postImageUrl: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  recommendationParams!: RecommendationParams;
  public isCategoryOpen: boolean = false;
  tagSearchResults!: any;
  tagSearchQuery!: any;
  tagSearchResultArray: any[] = [];

  //get username from tagSearchResultArray
  gettagSearchResultArrayUsernames() {
    return this.tagSearchResultArray.map((user) => user.userName);
  }
  public isTagOpen: boolean = false;
  constructor(
    private http: HttpClient,
    private authService: AuthenticationService
  ) {}
  sendpostImageUrl(data: any) {
    this.postImageUrl.next(data);
  }

  getpostImageUrl() {
    return this.postImageUrl.asObservable();
  }

  getPostParams(userId: string, pageSize: number, pageNumber: number) {
    this.PostParams = new PostParams();
    this.PostParams.orderBy = 'CreatedAt';
    this.PostParams.pageNumber = pageNumber;
    this.PostParams.pageSize = pageSize;
    this.PostParams.userId = userId;

    return this.PostParams;
  }

  setPostParams(params: PostParams) {
    this.PostParams = params;
  }

  resetPostParams(user: User) {
    if (user) {
      return this.PostParams;
    }
    return;
  }

  getRecommendationParams(
    userId: string,
    pageSize: number,
    pageNumber: number
  ) {
    this.recommendationParams = new RecommendationParams();
    this.recommendationParams.pageNumber = pageNumber;
    this.recommendationParams.pageSize = pageSize;
    this.recommendationParams.userId = userId;
    return this.recommendationParams;
  }
  setRecommendationParams(params: RecommendationParams) {
    this.recommendationParams = params;
  }
  resetRecommendationParams(user: User) {
    if (user) {
      return this.recommendationParams;
    }
    return;
  }

  getPosts(postParams: PostParams) {
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
    );
  }
  getRecomendedPosts(postParams: PostParams) {
    let params = getPaginationHeaders(
      postParams.orderBy.toString(),
      postParams.userId.toString(),

      postParams.pageNumber,
      postParams.pageSize
    );

    return getPaginatedResult<Post[]>(
      this.baseUrl + 'Post/get-recommended-posts',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );
  }
  getMostRecentPosts(postParams: PostParams) {
    let params = getPaginationHeaders(
      postParams.orderBy.toString(),
      postParams.userId.toString(),

      postParams.pageNumber,
      postParams.pageSize
    );

    return getPaginatedResult<Post[]>(
      this.baseUrl + 'Post/get-most-recent-posts',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );
  }
  getPostsByFollowing(recommendationParams: RecommendationParams) {
    let params = getPaginationHeaders(
      recommendationParams.orderBy.toString(),
      recommendationParams.userId.toString(),

      recommendationParams.pageNumber,
      recommendationParams.pageSize
    );
    return getPaginatedResult<Post[]>(
      this.baseUrl + 'Post/get-posts-by-following',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );
  }

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

  getPostsByUserId(postParams: PostParams) {
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
    );
  }

  setMainPostImage(postImageId: number, postId: number) {
    return this.http.put(
      this.baseUrl + 'User/set-main-post-image/' + postImageId,
      {
        postImageId,
        postId,
      }
    );
  }

  deletePostImage(postImageId: number, postId: number) {
    return this.http.delete(
      this.baseUrl + 'User/delete-post-image/' + postImageId
    );
  }

  openCategoryPopup() {
    this.isCategoryOpen = true;
  }

  closeCategoryPopup() {
    this.isCategoryOpen = false;
  }

  openTagPopup() {
    this.isTagOpen = true;
  }

  CloseTagPopup() {
    this.isTagOpen = false;
  }
}
