import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { Component, Input, OnInit } from '@angular/core';
import { Apartment } from '../../types/apartment';
import { Router, RouteReuseStrategy, RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'apartment',
  standalone: true,
  imports: [
    CardModule,
    ButtonModule,
    RouterModule,
    CommonModule],
  templateUrl: './apartment.component.html',
  styleUrl: './apartment.component.css'
})

export class ApartmentComponent implements OnInit {
  @Input() apartment!: Apartment;

  constructor(private router: Router,
              private authService: AuthService
  ){}

  ngOnInit(): void {
    console.log(this.apartment);
    this.apartment.imageUrl = this.getApartmentImage(this.apartment);
  }

  getApartmentImage(apartment: Apartment): string {
    const imageUrl : string = "";

    return imageUrl;
  }

  isLoggedIn(){
    return this.authService.isLoggedIn();
  }
}
