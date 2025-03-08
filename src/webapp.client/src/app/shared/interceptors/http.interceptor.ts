import { HttpInterceptorFn } from '@angular/common/http';

export const httpInterceptor: HttpInterceptorFn = (req, next) => {
  return next(
    req.clone({
      withCredentials: true, // TODO: Check if this is necessary
      headers: req.headers.set('Access-Control-Allow-Credentials', 'true ') // TODO: This makes the site vulnerable to Cross-Site Request Forgery (CSRF) attacks
    })
  );
};
