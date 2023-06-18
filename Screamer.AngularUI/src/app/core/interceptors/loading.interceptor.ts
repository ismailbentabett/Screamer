import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { delay, finalize, identity, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BusyService } from '../services/busy.service';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  constructor(private busyService: BusyService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if (request.method === 'GET') {
      this.busyService.busy();
    }

    return next.handle(request).pipe(
      (environment.production ? identity : delay(1000)),
      finalize(() => {
        if (request.method === 'GET') {
          this.busyService.idle();
        }
      })
    );
  }

}
