import { ApartmentService } from './../../services/apartment.service';
import { Component } from '@angular/core';
import { RegisterUser } from '../../types/registerUser';
import { NgForm } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ButtonModule
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
    password: ''
  };
  constructor(private apartmentService: ApartmentService){}

  onSubmit(form: NgForm) {
    if (form.valid) {

      this.apartmentService.registration(this.registerUser)
      .subscribe(isSuccessfull =>
        this.isSuccessfull = isSuccessfull
      );
      console.log('Form Submitted!', this.registerUser);
    }
  }
}
