import { HttpInterceptorFn } from '@angular/common/http';
import { AuthService } from '../services/auth.service';
import { throwError } from 'rxjs/internal/observable/throwError';
import { inject } from '@angular/core';

export const httpInterceptor: HttpInterceptorFn = (req, next) => {
  const authService: AuthService = inject(AuthService);

  
  if (!authService.isLoggedIn && !req.url.includes('/auth')) {
    return throwError(() => new Error('HTTP error: User is not logged in'));
  }

  return next(
    req.clone({
      withCredentials: true, // TODO: Check if this is necessary
      headers: req.headers.set('Access-Control-Allow-Credentials', 'true ') // TODO: This makes the site vulnerable to Cross-Site Request Forgery (CSRF) attacks
    })
  );
};
