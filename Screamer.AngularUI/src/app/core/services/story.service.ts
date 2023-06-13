import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class StoryService {
  public isOpen: boolean = false;
  baseUrl = environment.baseWebApiUrl;

  constructor(private http: HttpClient) {}

  openPopup() {
    this.isOpen = true;
  }

  closePopup() {
    this.isOpen = false;
  }

  AddStory(story: any) {
    return this.http.post(this.baseUrl + 'Story', story);
  }

  getStories(currentUserId: any) {
    return this.http.get(
      this.baseUrl + 'Story/by-following?userId=' + currentUserId
    );
  }
}
