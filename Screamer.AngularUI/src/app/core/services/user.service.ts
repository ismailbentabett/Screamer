import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AuthenticationService } from './authentication.service';
import { User } from '../models/User';
import { BehaviorSubject, map, of, take } from 'rxjs';
import { UserParams } from '../models/userParams';
import {
  getPaginatedResult,
  getPaginationHeaders,
} from '../Helpers/paginationHelper';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseUrl = environment.baseWebApiUrl;
  user?: any;
  users: User[] = [];
  userParams: UserParams | undefined;
  memberCache: any;

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

  getUserParams() {
    return this.userParams;
  }

  setUserParams(params: UserParams) {
    this.userParams = params;
  }
  getUser() {
    return this.http.get<User>(this.baseUrl + 'User');
  }

  resetUserParams() {
    if (this.user) {
      return this.userParams;
    }
    return;
  }
  getUsers(userParams: UserParams) {
    let params = getPaginationHeaders(
      userParams.pageNumber,
      userParams.pageSize
    );

    params = params.append('orderBy', userParams?.orderBy);

    return getPaginatedResult<User[]>(
      this.baseUrl + 'User',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );
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
    return this.http.get<User>(this.baseUrl + 'User/' + this.user.id);
  }

  setMainAvatar(avatarId: any) {
    return this.http.put(this.baseUrl + 'User/set-main-avatar/' + avatarId, {});
  }

  deleteAvatar(avatarId: any) {
    return this.http.delete(this.baseUrl + 'User/delete-avatar/' + avatarId);
  }
}
