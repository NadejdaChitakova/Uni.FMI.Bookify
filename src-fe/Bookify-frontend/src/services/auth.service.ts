import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Login } from '../types/login';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  httpClient = inject(HttpClient);
  router = inject(Router)
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
    console.log("is logged in: " + this.getToken() !== null)
    return this.getToken() !== null;
  }

  login(login: Login){
    const url = "https://localhost:44360/api/Users/Login";

    this.httpClient.post<any>(url,login).subscribe({
      next: (data) => {
        this.setToken(data);
        this.router.navigate(["/"])
      },
      error: (err) => {
        this.setToken(null)
      }
    });
  }

  logout(){
    this.setToken(null);
    this.router.navigate(["/login"])
  }
}
