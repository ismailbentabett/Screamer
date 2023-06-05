import { Injectable } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class CommentService {
  baseUrl: string = environment.baseWebApiUrl;

  constructor(
    private http: HttpClient,
    private authService: AuthenticationService
  ) {}

  createComment(comment: any) {
    return this.http.post(this.baseUrl + 'Post/add-comment', comment);
  }
  createReply(comment: any) {
    return this.http.post(this.baseUrl + 'Post/add-reply', comment);
  }
}
