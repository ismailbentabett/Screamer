import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AuthenticationService } from './authentication.service';
import { User } from '../models/User';
import { BehaviorSubject, take } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseUrl = environment.baseWebApiUrl;
  user?: any;
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

  getUser() {
    return this.http.get<User>(this.baseUrl + 'User');
  }
  updateUser(user: User) {
    return this.http.put(this.baseUrl + 'User', user);
  }

  getUserById(id: number) {
    return this.http.get<User>(this.baseUrl + 'User/' + id);
  }

  deleteUser(id: number) {
    return this.http.delete(this.baseUrl + 'User/' + id);
  }

  getUserByUsername(username: string) {
    return this.http.get<User>(this.baseUrl + 'User/username/' + username);
  }
  getCurrentUserData() {
    return this.http
      .get<User>(this.baseUrl + 'User/' + this.user.id)

  }

  setMainAvatar(avatarId: any) {
    return this.http.put(this.baseUrl + 'User/set-main-avatar/' + avatarId, {});
  }

  deleteAvatar(avatarId: any) {
    return this.http.delete(this.baseUrl + 'User/delete-avatar/' + avatarId);
  }
}
