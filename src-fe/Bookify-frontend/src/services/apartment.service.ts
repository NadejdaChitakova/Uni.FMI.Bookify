import { SearchApartmentRequest } from './../types/searchApartmentRequest';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Apartment } from '../types/apartment';
import { Apartments } from '../types/apartments';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class ApartmentService {
  // headers= new HttpHeaders()
  // .set('content-type', 'application/json')
  // .set('Access-Control-Allow-Origin', '*');

  constructor(private http: HttpClient) { }

  getApartments(id:string) :Observable<Apartment> {
    const url = "http://localhost:58314/api/Apartments/GetApartmentById?id=99e5ce01-763e-42c4-a55f-ffb3b3c8a02d";

     return this.http.get<Apartment>(url);
  }

  getAll(request: SearchApartmentRequest ) :Observable<Apartment[]> {
    const url = "http://localhost:58314/api/Apartments/GetAll";

     return this.http.post<Apartment[]>(url, request);
  }
}