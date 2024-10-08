import { SearchApartmentRequest } from './../types/searchApartmentRequest';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Apartment } from '../types/apartment';
import { Apartments } from '../types/apartments';
import { HttpHeaders } from '@angular/common/http';
import { UpdateApartmentRequest } from '../types/UpdateApartmentRequest';
import { Login } from '../types/login';
import { RegisterUser } from '../types/registerUser';
import { InsertApartment } from '../types/insertApartment';
import { GetUnavailableDate } from '../types/getUnavailableDate';
import { ReserveRequest } from '../types/ReserveRequest';
import { GetMyApartments } from '../types/getMyApartments';
import { url } from 'inspector';
import { GetMyApartmentReservations } from '../types/getMyApartmentReservations';

@Injectable({
  providedIn: 'root'
})

export class ApartmentService {

  constructor(private http: HttpClient) { }

  getApartments(id:string) :Observable<Apartment> {
    const url = "https://localhost:44360/api/Apartments/GetApartmentById?id="+id;

     return this.http.get<Apartment>(url);
  }

  getAll(request: SearchApartmentRequest ) :Observable<Apartment[]> {
    const url = "https://localhost:44360/api/Apartments/GetAll";

     return this.http.post<Apartment[]>(url, request);
  }

  getUnavailablePeriods(request: GetUnavailableDate): Observable<string[]>{
    const url = "https://localhost:44360/api/Apartments/GetUnavailableDate";

    return this.http.post<string[]>(url, request);
  }

  uploadImage(formData: FormData) : Observable<string[]>{
    const url = "https://localhost:44360/api/ApartmentImage/UploadPhoto";

    console.log("posting data")
    return this.http.post<string[]>(url, formData);
  }

  insert(request: InsertApartment) : Observable<any> {
    const url = "https://localhost:44360/api/Apartments/Create";

     return this.http.post<any>(url, request);
  }

  update(request: UpdateApartmentRequest) : Observable<any> {
    const url = "https://localhost:44360/api/Apartments/Update";

     return this.http.post<any>(url, request);
  }

  downloadApartmentImages(apartmentId: string) : Observable<any> {
    const url = "https://localhost:44360/api/ApartmentImage/GetApartmentImage?imageId="+apartmentId;

     return this.http.get<any>(url);
  }

  deletePhoto(apartmentImageId: string) :Observable<any>{
    const url = "https://localhost:44360/api/ApartmentImage/Delete?id="+apartmentImageId;

    return this.http.delete<any>(url);
  }

  login(login: Login): Observable<any>{
    const url = "https://localhost:44360/api/Users/Login";

    return this.http.post<any>(url,login);
  }

  registration(registration: RegisterUser): Observable<any>{
    const url = "https://localhost:44360/api/Users/Registration";

    return this.http.post<any>(url,registration);
  }

  getMyApartments() : Observable<GetMyApartments[]>{
    const url = "https://localhost:44360/api/Apartments/GetMyApartments";

    return this.http.get<GetMyApartments[]>(url);
  }

  getmyApartmentReservations(apartmentId: string): Observable<GetMyApartmentReservations>{
    const url = "https://localhost:44360/api/Apartments/GetMyApartmentReservations?apartmentId="+ apartmentId;

    return this.http.get<GetMyApartmentReservations>(url);
  }
}
