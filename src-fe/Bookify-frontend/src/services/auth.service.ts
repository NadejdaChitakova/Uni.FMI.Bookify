import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Login } from '../types/login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  httpClient = inject(HttpClient);
  constructor() { }

  setToken(token: string | null) {
    console.log(window)
    if(token !== null) {
      window.localStorage.setItem("auth_token", token)
    }
    else {
      window.localStorage.removeItem("auth_token")
    }
  }

  getToken() {
    if(typeof window !== "undefined"){
      return window.localStorage.getItem("auth_token")
    }

    return null
  }

  isLoggedIn(){
    console.log(this.getToken())
    return this.getToken() !== null;
  }

  login(login: Login){
    const url = "http://localhost:58314/api/Users/Login";

    this.httpClient.post<any>(url,login).subscribe({
      next: (data) => {
        this.setToken(data);
      },
      error: (err) => {
        this.setToken(null)
      }
    });
  }
}
