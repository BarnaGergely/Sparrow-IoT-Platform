import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { User } from '../models/user.model';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  http: HttpClient = inject(HttpClient);

  isLoggedIn: boolean = false;

  constructor() { 
    setInterval(() => {
      this.isLoggedIn = this.checkIsLoggedIn();
      if (!this.isLoggedIn) {
        console.warn('User is not logged in');
      }
    }, 10000);
  }

  // TODO: specify the return type, track login status
  login(user: User) {
    return this.http.post<void>(environment.apiUrl + '/public/auth/login', {
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
    this.isLoggedIn = false;
  }

  // TODO: specify the return type
  register(user: User) {
    return this.http.post<void>(environment.apiUrl + '/public/auth/register', {
      "email": user.email,
      "password": user.password,
    });
  }

  checkIsLoggedIn(): boolean {
    const authCookie = document.cookie.split('; ').find(row => row.startsWith('.AspNetCore.Identity.Application='));
    return !!authCookie;
  }
}
