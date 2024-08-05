import { ApartmentService } from './../../services/apartment.service';
import { Component } from '@angular/core';
import { RegisterUser } from '../../types/registerUser';
import { NgForm } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ButtonModule,
    RouterModule
  ],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {
  isSuccessfull : any;
  registerUser: RegisterUser = {
    firstname: '',
    lastname: '',
    phoneNumber: '',
    email: '',
    password: '',
    registerLikeOwner : null
  };
  constructor(private apartmentService: ApartmentService){}

  onSubmit() {
      this.apartmentService.registration(this.registerUser)
      .subscribe(isSuccessfull =>
        this.isSuccessfull = isSuccessfull
      );
      console.log('Form Submitted!', this.registerUser);

  }
}
