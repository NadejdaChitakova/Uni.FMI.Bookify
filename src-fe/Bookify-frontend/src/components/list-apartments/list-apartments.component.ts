
import { ApartmentService } from './../../services/apartment.service';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ApartmentComponent } from '../apartment/apartment.component';
import { Apartment } from '../../types/apartment';
import { SearchApartmentRequest } from '../../types/searchApartmentRequest';
import { Paging } from '../../types/Paging';
import { ButtonModule } from 'primeng/button';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-list-apartments',
  standalone: true,
  imports: [HttpClientModule,
      ApartmentComponent,
      ButtonModule,
      RouterModule],
  templateUrl: './list-apartments.component.html',
  styleUrl: './list-apartments.component.css',
})

export class ListApartmentsComponent implements OnInit{
  apartment!: Apartment;
  apartments!: Apartment[];
  paging: Paging = {PageSize:10, PageIndex:0};
  requestBody: SearchApartmentRequest = {
    searchByLocationOrName: '',
    numberOfGuests: 0,
    cityId: '',
    countryId: '',
    endDate: null,
    fromDate: null,
    maxPrice: null,
    minPrice: null,
    paging: this.paging};
  error: any;
  constructor(private apartmentService: ApartmentService){}

  ngOnInit() {

    this.apartmentService.getAll(this.requestBody)
    .subscribe({
      next: (data) => {
        this.apartments = data;
        console.log(this.apartments);
      },
      error: (error) => {
        console.log(error, "test");
      }
    });


  }
}
