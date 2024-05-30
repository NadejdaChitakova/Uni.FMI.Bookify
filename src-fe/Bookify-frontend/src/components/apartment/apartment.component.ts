import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { Component, Input, OnInit } from '@angular/core';
import { Apartment } from '../../types/apartment';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'apartment',
  standalone: true,
  imports: [CardModule, ButtonModule, RouterModule],
  templateUrl: './apartment.component.html',
  styleUrl: './apartment.component.css'
})

export class ApartmentComponent implements OnInit {
  @Input() apartment!: Apartment;

  ngOnInit(): void {
    this.apartment.imageUrl = this.getApartmentImage(this.apartment);
  }

  getApartmentImage(apartment: Apartment): string {
    const imageUrl : string = "";

    return imageUrl;
  }
}
