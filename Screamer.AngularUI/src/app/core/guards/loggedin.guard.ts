import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { map } from 'rxjs';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

export const loggedinGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);

  return inject(AuthenticationService).currentUser$.pipe(
    //use rote and state
    map((user: any) => {
      console.log(user);

      if (user) {
        router.navigateByUrl('/v/feed');
        return false;
      }
      // user not exist
      return true;
    })
  );
};
