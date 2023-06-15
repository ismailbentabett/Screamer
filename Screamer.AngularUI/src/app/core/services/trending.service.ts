import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TrendingService {
  hubUrl = environment.hubUrl;

  constructor(private http: HttpClient) {}

  getTopPreformingPost() {
    return this.http.get(this.hubUrl + 'Post/get-the-top-preforming-post');
  }

  getTopPreformingPosts() {
    return this.http.get(this.hubUrl + 'Post/get-the-top-preforming-posts');
  }

  getPostsByHashtag() {
    return this.http.get(this.hubUrl + 'Post/get-posts-by-hashtag');
  }

  getPostsByCategory() {
    return this.http.get(this.hubUrl + 'Post/get-posts-by-category');
  }

  getTrendingPosts() {
    return this.http.get(this.hubUrl + 'Post/get-trending-posts');
  }

  getTopPreformingUser() {
    return this.http.get(this.hubUrl + 'User/top-preforming-user');
  }

  getTopPreformingUsers() {
    return this.http.get(this.hubUrl + 'User/top-preforming-users');
  }
}
