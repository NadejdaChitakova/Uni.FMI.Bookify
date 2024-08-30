import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReserveRequest } from '../types/ReserveRequest';
import { Observable } from 'rxjs';
import { MyReservations } from '../types/myReservations';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private http : HttpClient) { }

  getMyReservation(): Observable<MyReservations[]>{
    const url = "https://localhost:44360/api/Booking/GetMyReservation";

    return this.http.get<MyReservations[]>(url);
  }

  bookApartment(request: ReserveRequest) : Observable<any>{
    const url = "https://localhost:44360/api/Booking/Reserve";

    return this.http.post<any>(url, request);
  }

  declineReservation(reservationId: string): Observable<any>{
    const url = "https://localhost:44360/api/Booking/DeclineReservation?id="+reservationId;

    return this.http.delete(url);
  }
}
