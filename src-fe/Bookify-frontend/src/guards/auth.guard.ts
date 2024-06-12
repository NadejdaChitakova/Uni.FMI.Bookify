import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = (route, state) => {
  let auth = inject(AuthService);
  let router = inject(Router)
  console.log("guard", auth.isLoggedIn())
  if(auth.isLoggedIn()){
    return true;
  }

  router.navigate(["/login"])
  return false;
};
