import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { NotificationService } from '../services/notification.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(
    private authService: AuthenticationService,
    private jwtHelper: JwtHelperService,
    private notificationService: NotificationService
  ) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    this.authService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => {
        if (user) {
          let roomId = user.id;
          this.notificationService.startConnection(user, roomId);

          //join the room
          this.notificationService.joinRoom(roomId as any);

          this.notificationService.notificationRecieved$.subscribe({
            next: (message: any) => {
              console.log(message);
            },
          });

          request = request.clone({
            setHeaders: {
              Authorization: `Bearer ${user.token}`,
            },
          });
        }
      },
    });
    //check if token is expired
    const isTokenExpired = this.jwtHelper.isTokenExpired();

    if (isTokenExpired) {
      this.authService.logout();
    }
    return next.handle(request);
  }
}
