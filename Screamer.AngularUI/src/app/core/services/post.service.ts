import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { take } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  baseUrl = environment.baseWebApiUrl;

  constructor(private http: HttpClient) {}

  getPosts() {
    return this.http.get(this.baseUrl + 'Post');
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

  getPostsByUserId(id: number) {
    return this.http.get(this.baseUrl + 'Post/user/' + id);
  }
}
