import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BookmarkService {
  baseUrl = environment.baseWebApiUrl;

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
}
