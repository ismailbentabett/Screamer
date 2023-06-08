import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject, map } from 'rxjs';
import { User } from 'src/app/core/models/User';
import { PresenceService } from './presence.service';
import { SocialAuthService, SocialUser } from '@abacritt/angularx-social-login';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  baseUrl = environment.baseWebApiUrl;
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  private authChangeSub = new Subject<boolean>();
  private extAuthChangeSub = new Subject<SocialUser>();
  public authChanged = this.authChangeSub.asObservable();
  public extAuthChanged = this.extAuthChangeSub.asObservable();
  constructor(
    private http: HttpClient,
    private presenceService: PresenceService,
    private router: Router
  ) {}

  login(model: any) {
    return this.http.post<User>(this.baseUrl + 'Auth/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          this.setCurrentUser(user);
          this.presenceService.createHubConnection(user);
        }
      })
    );
  }

  register(model: any) {
    return this.http.post<User>(this.baseUrl + 'Auth/register', model).pipe(
      map((user: User) => {
        if (user) {
          this.presenceService.createHubConnection(user);
        }
      })
    );
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    //token
    localStorage.setItem('token', JSON.stringify(user.token));
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
    this.presenceService.stopHubConnection();
  }

  getDecodedToken(token: string) {
    return JSON.parse(atob(token.split('.')[1]));
  }

  externallogin(model: any) {
    console.log({
      provider: model.provider,
      accessToken: model.token,
    });

    /* Auth/external/google */
    return this.http
      .post<User>(this.baseUrl + 'Auth/external/google', {
        provider: model.provider,
        accessToken: model.token,
      })
      .subscribe((response) => {
        const user = response;
        if (user) {
          this.setCurrentUser(user);
          this.presenceService.createHubConnection(user);

          this.router.navigate(['/v/feed']);
        }
      });
    /*  .pipe(
        map((response: User) => {

        })
      ); */
  }
}
