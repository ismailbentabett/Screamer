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
  getThePaginationHeaders,
} from '../Helpers/paginationHelper';
import { FollowParams } from '../models/FollowParams';
import { UserUpdateInput } from '../models/UserUpdateInput';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseUrl = environment.baseWebApiUrl;
  user?: any;
  users: User[] = [];
  userParams: UserParams | undefined;
  memberCache: any;
  followeParams!: FollowParams;

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
    this.userParams = new UserParams();
    this.userParams.orderBy = 'CreatedAt';
    this.userParams.pageNumber = 1;
    this.userParams.pageSize = 1;
    this.userParams.userId = this.user.id;

    return this.userParams;
  }

  setUserParams(params: UserParams) {
    this.userParams = params;
  }

  resetUserParams() {
    if (this.user) {
      return this.userParams;
    }
    return;
  }
  getUsers(userParams: UserParams) {
    let params = getPaginationHeaders(
      userParams.orderBy.toString(),
      userParams.userId.toString(),

      userParams.pageNumber,
      userParams.pageSize
    );

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

  updateUser(user: UserUpdateInput , id : number) {
    console.log(
      {
        user,
        id,
      }
    )
    return this.http.put(this.baseUrl + 'User', {
      ...user,
      id,
    });
  }

  getUserById(id: string) {
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
  setMainCover(coverId: any) {
    return this.http.put(this.baseUrl + 'User/set-main-cover/' + coverId, {});
  }

  deleteCover(coverId: any) {
    return this.http.delete(this.baseUrl + 'User/delete-cover/' + coverId);
  }

  addFollow(sourceUserId: any, targetUserId: any) {
    return this.http.post(
      this.baseUrl +
        `Follow?targetUserId=${targetUserId}&sourceUserId=${sourceUserId}`,
      {}
    );
  }

  removeFollow(sourceUserId: string, targetUserId: string) {
    return this.http.delete(
      this.baseUrl +
        `Follow?targetUserId=${targetUserId}&sourceUserId=${sourceUserId}`,
      {}
    );
  }

  getFollows(followParams: FollowParams) {
    let params = getThePaginationHeaders(
      followParams.pageNumber,
      followParams.pageSize
    );

    params = params.append('predicate', followParams.predicate!);
    params = params.append('UserId', followParams.userId!.toString());

    return getPaginatedResult<any[]>(
      this.baseUrl + 'Follow',
      params,
      this.http
    );
  }
}
