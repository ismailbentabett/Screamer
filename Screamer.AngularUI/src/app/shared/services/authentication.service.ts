import { environment } from './../../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  private token!: string | null;
  private userSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public user$: Observable<any> = this.userSubject.asObservable();
  constructor(private http: HttpClient, private router: Router) {}
  private baseUrl = 'http://localhost:3000';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  public register(
    firstName: string,
    lastName: string,
    email: string,
    password: string,
    userName: string
  ): Observable<any> {
    //after you register you login automatically
    return this.http.post<any>(
      `${environment.baseWebApiUrl}/api/Auth/register`,
      { firstName, lastName, email, password, userName },
      this.httpOptions
    );
  }

  public login(username: string, password: string): Observable<any> {
    return this.http
      .post<any>(
        `${environment.baseWebApiUrl}/api/login`,
        { username, password },
        this.httpOptions
      )
      .pipe(
        tap((response) => {
          this.token = response.token;
          localStorage.setItem('token', this.token as any);
          this.fetchUser();
        })
      );
  }

  public logout(): void {
    this.token = null;
    localStorage.removeItem('token');
    this.userSubject.next(null);
  }

  public isAuthenticated(): boolean {
    return !!this.token;
  }

  public fetchUser(): void {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${this.token}`,
    });
    this.http
      .get<any>(`${environment.baseWebApiUrl}/api/user`, { headers })
      .subscribe((user) => this.userSubject.next(user));
  }
}
