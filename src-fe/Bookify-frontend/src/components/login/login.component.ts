import { AuthService } from './../../services/auth.service';
import { Login } from './../../types/login';
import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApartmentService } from '../../services/apartment.service';
import { ButtonModule } from 'primeng/button';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,
    FormsModule,
    ButtonModule,
    RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  // token: string = '';

  authService = inject(AuthService)

  constructor(private apartmentService: ApartmentService){}

  onSubmit(){
    var login: Login = {email: this.username, password: this.password};
    console.log(this.username)
    this.authService.login(login)
  }
}
