import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PostParams } from '../models/PostParams';
import { UserParams } from '../models/userParams';
import {
  getCategoryPaginationHeaders,
  getHashtagPaginationHeaders,
  getPaginatedResult,
  getPaginationHeaders,
} from '../Helpers/paginationHelper';
import { map, take } from 'rxjs';
import { Post } from '../models/Post';
import { User } from '../models/User';
import { AuthenticationService } from './authentication.service';
import { CategoryPostParams } from '../models/CategoryPostParams';
import { HashtagPostParams } from '../models/HashtagPostParams';

@Injectable({
  providedIn: 'root',
})
export class TrendingService {
  baseUrl = environment.baseWebApiUrl;
  TopPreformingPosts: PostParams | undefined;
  PostsByHashtag: HashtagPostParams | undefined;
  PostsByCategory: CategoryPostParams | undefined;
  TrendingPosts: PostParams | undefined;
  TopPreformingUsers: UserParams | undefined;
  user: any;
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

  getTopPreformingPost() {
    return this.http.get(this.baseUrl + 'Post/get-the-top-preforming-post');
  }

  getTopPreformingPosts(postParams: PostParams) {
    let params = getPaginationHeaders(
      postParams.orderBy.toString(),
      postParams.userId.toString(),

      postParams.pageNumber,
      postParams.pageSize
    );
    return getPaginatedResult<Post[]>(
      this.baseUrl + 'Post/get-the-top-preforming-posts',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );
  }

  getPostsByHashtag(postParams: HashtagPostParams) {
    let params = getHashtagPaginationHeaders(
      postParams.orderBy.toString(),
      postParams.userId.toString(),

      postParams.pageNumber,
      postParams.pageSize,
      postParams.hashtagName
    );
    return getPaginatedResult<Post[]>(
      this.baseUrl + 'Post/get-posts-by-hashtag',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );
  }

  getPostsByCategory(postParams: CategoryPostParams) {
    let params = getCategoryPaginationHeaders(
      postParams.orderBy.toString(),
      postParams.userId.toString(),

      postParams.pageNumber,
      postParams.pageSize,
      postParams.category
    );
    return getPaginatedResult<Post[]>(
      this.baseUrl + 'Post/get-posts-by-category',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );
  }

  getTrendingPosts(postParams: PostParams) {
    let params = getPaginationHeaders(
      postParams.orderBy.toString(),
      postParams.userId.toString(),

      postParams.pageNumber,
      postParams.pageSize
    );
    return getPaginatedResult<Post[]>(
      this.baseUrl + 'Post/get-trending-posts',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );
  }

  getTopPreformingUser() {
    return this.http.get(this.baseUrl + 'User/top-preforming-user');
  }

  getTopPreformingUsers(userParams: UserParams) {
    let params = getPaginationHeaders(
      userParams.orderBy.toString(),
      userParams.userId.toString(),

      userParams.pageNumber,
      userParams.pageSize
    );
    return getPaginatedResult<User[]>(
      this.baseUrl + 'User/top-preforming-users',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );
  }

  getTopPreformingPostsParams(
    userId: string,
    pageSize: number,
    pageNumber: number
  ) {
    this.TopPreformingPosts = new PostParams();
    this.TopPreformingPosts.orderBy = 'CreatedAt';
    this.TopPreformingPosts.pageNumber = pageNumber;
    this.TopPreformingPosts.pageSize = pageSize;
    this.TopPreformingPosts.userId = userId;

    return this.TopPreformingPosts;
  }

  setTopPreformingPostsParams(params: PostParams) {
    this.TopPreformingPosts = params;
  }

  getPostsByHashtagParams(
    userId: string,
    pageSize: number,
    pageNumber: number,
    hashtagName: string
  ) {
    this.PostsByHashtag = new HashtagPostParams();
    this.PostsByHashtag.orderBy = 'CreatedAt';
    this.PostsByHashtag.pageNumber = pageNumber;
    this.PostsByHashtag.pageSize = pageSize;
    this.PostsByHashtag.userId = userId;
    this.PostsByHashtag.hashtagName = hashtagName;

    return this.PostsByHashtag;
  }

  setPostsByHashtagParams(params: HashtagPostParams) {
    this.PostsByHashtag = params;
  }

  getPostsByCategoryParams(
    userId: string,
    pageSize: number,
    pageNumber: number,
    category: string
  ) {
    this.PostsByCategory = new CategoryPostParams();
    this.PostsByCategory.orderBy = 'CreatedAt';
    this.PostsByCategory.pageNumber = pageNumber;
    this.PostsByCategory.pageSize = pageSize;
    this.PostsByCategory.userId = userId;
    this.PostsByCategory.category = category;

    return this.PostsByCategory;
  }

  setPostsByCategoryParams(params: CategoryPostParams) {
    this.PostsByCategory = params;
  }

  getTrendingPostsParams(userId: string, pageSize: number, pageNumber: number) {
    this.TrendingPosts = new PostParams();
    this.TrendingPosts.orderBy = 'CreatedAt';
    this.TrendingPosts.pageNumber = pageNumber;
    this.TrendingPosts.pageSize = pageSize;
    this.TrendingPosts.userId = userId;

    return this.TrendingPosts;
  }

  setTrendingPostsParams(params: PostParams) {
    this.TrendingPosts = params;
  }

  getTopPreformingUsersParams() {
    this.TopPreformingUsers = new UserParams();
    this.TopPreformingUsers.orderBy = 'CreatedAt';
    this.TopPreformingUsers.pageNumber = 1;
    this.TopPreformingUsers.pageSize = 10;
    this.TopPreformingUsers.userId = this.user.id;

    return this.TopPreformingUsers;
  }

  setTopPreformingUsersParams(params: UserParams) {
    this.TopPreformingUsers = params;
  }
}
