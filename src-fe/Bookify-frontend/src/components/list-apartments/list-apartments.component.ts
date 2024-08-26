
import { ApartmentService } from './../../services/apartment.service';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ApartmentComponent } from '../apartment/apartment.component';
import { Apartment } from '../../types/apartment';
import { SearchApartmentRequest } from '../../types/searchApartmentRequest';
import { Paging } from '../../types/Paging';
import { ButtonModule } from 'primeng/button';
import { Router, RouterModule } from '@angular/router';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputNumberModule } from 'primeng/inputnumber';
import { CalendarModule } from 'primeng/calendar';
import { PanelModule } from 'primeng/panel';
import { InputGroupModule } from 'primeng/inputgroup';

@Component({
  selector: 'app-list-apartments',
  standalone: true,
  imports: [
      HttpClientModule,
      ApartmentComponent,
      ButtonModule,
      RouterModule,
      FormsModule,
      InputTextModule,
      FloatLabelModule,
      InputNumberModule,
      CalendarModule,
      RouterModule,
      PanelModule,
      InputGroupModule],
  templateUrl: './list-apartments.component.html',
  styleUrl: './list-apartments.component.css',
})

export class ListApartmentsComponent implements OnInit{
  rangeDates: Date[] | undefined;
  apartment!: Apartment;
  apartments!: Apartment[];
  paging: Paging = {PageSize:10, PageIndex:0};
  requestBody: SearchApartmentRequest = {
    searchByLocationOrName: '',
    numberOfGuests: 0,
    cityId: '',
    countryId: '',
    duration: null,
    maxPrice: null,
    minPrice: null,
    paging: this.paging};
  error: any;
  constructor(private apartmentService: ApartmentService,
              private router: Router
  ){}

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

  load(){
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
    this.router.navigate(['/']);
  }
}
