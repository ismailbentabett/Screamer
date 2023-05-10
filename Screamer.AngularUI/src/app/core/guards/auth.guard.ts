import { CanActivateFn, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { inject } from '@angular/core';
import { map } from 'rxjs';

export const authGuard: CanActivateFn = (route, state) => {
  const router = inject(Router)

  return inject(AuthenticationService).currentUser$.pipe(
    //use rote and state
    map((user) => {
      console.log(user)

      if (!user) {
        router.navigateByUrl('/login');
        return false;
      }
      // user exists
      return true;
    })
  );
};
