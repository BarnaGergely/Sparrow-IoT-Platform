import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  http: HttpClient = inject(HttpClient);

  // TODO: specify the return type
  login(user: User) {
    return this.http.post<void>(environment.apiUrl + '/auth/login', {
      "email": user.email,
      "password": user.password,
    }, {
      params: {
        useCookies: 'true'
      }
    });
  }

  // TODO: specify the return type
  logout() {
    // delete auth cookie
    document.cookie = '.AspNetCore.Identity.Application=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/';
  }

  // TODO: specify the return type
  register(user: User) {
    return this.http.post<void>(environment.apiUrl + '/auth/register', {
      "email": user.email,
      "password": user.password,
    });
  }

  isLoggedIn(): boolean {
    const authCookie = document.cookie.split('; ').find(row => row.startsWith('.AspNetCore.Identity.Application='));
    return !!authCookie;
  }
}
