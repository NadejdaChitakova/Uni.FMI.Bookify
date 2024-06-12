import { HttpInterceptorFn } from '@angular/common/http';
import { AuthService } from './auth.service';
import { inject } from '@angular/core';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  let authService = inject(AuthService)
  let authToken = authService.getToken()
  console.log("auth token in jwt int", authToken)

  if(authToken != null) {

    const reqWithToken = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${authToken}`),
      });
    console.log("Req=  ",req)
    return next(reqWithToken)
  }

  return next(req);
};
