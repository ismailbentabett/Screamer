import { CanActivateFn } from '@angular/router';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { inject } from '@angular/core';
import { map } from 'rxjs';

export const authGuard: CanActivateFn = (route, state) => {
  return inject(AuthenticationService).currentUser$.pipe(
    //use rote and state
    map((user) => {
      if (user) {
        return true;
      }
      return false;
    }

    )
  );
};
