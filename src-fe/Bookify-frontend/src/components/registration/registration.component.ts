import { Component } from '@angular/core';
import { RegisterUser } from '../../types/registerUser';
import { NgForm } from '@angular/forms';

import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {
  registerUser: RegisterUser = {
    firstname: '',
    lastname: '',
    phoneNumber: '',
    email: '',
    password: ''
  };

  onSubmit(form: NgForm) {
    if (form.valid) {
      console.log('Form Submitted!', this.registerUser);
    }
  }
}
