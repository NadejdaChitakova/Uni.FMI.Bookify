
import { ApartmentService } from './../../services/apartment.service';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ApartmentComponent } from '../apartment/apartment.component';
import { Apartment } from '../../types/apartment';
import { SearchApartmentRequest } from '../../types/searchApartmentRequest';
import { Paging } from '../../types/Paging';

@Component({
  selector: 'app-list-apartments',
  standalone: true,
  imports: [HttpClientModule, ApartmentComponent],
  templateUrl: './list-apartments.component.html',
  styleUrl: './list-apartments.component.css',
})

export class ListApartmentsComponent implements OnInit{
  apartment!: Apartment;
  apartments!: Apartment[];
  paging: Paging = {PageSize:10, PageIndex:0};
  requestBody: SearchApartmentRequest = {paging: this.paging};
  error: any;
  constructor(private apartmentService: ApartmentService){}

  ngOnInit() {
    // this.apartmentService.getApartments("99e5ce01-763e-42c4-a55f-ffb3b3c8a02d")
    // .subscribe({
    //   next: (data) => {
    //     this.apartment = data;
    //     console.log(this.apartment);
    //   },
    //   error: (error) => {
    //     console.log(error, "test");
    //   }
    // });

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
