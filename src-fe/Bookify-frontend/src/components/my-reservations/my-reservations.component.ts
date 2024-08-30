import { Component } from '@angular/core';
import { PanelModule } from 'primeng/panel';
import { TableModule } from 'primeng/table';
import { MyReservations } from '../../types/myReservations';
import { BookingService } from '../../services/booking.service';
import { Button, ButtonModule } from 'primeng/button';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-my-reservations',
  standalone: true,
  imports: [
    PanelModule,
    TableModule,
    ButtonModule,
    CommonModule
  ],
  templateUrl: './my-reservations.component.html',
  styleUrl: './my-reservations.component.css'
})
export class MyReservationsComponent {
 reservations: MyReservations[] = [];

 constructor(private bookingService: BookingService){}

 ngOnInit(){
    this.bookingService.getMyReservation()
    .subscribe({
      next: (data) => {
        this.reservations = data;
        console.log(this.reservations);
      },
      error: (error) => {
        console.log(error, "test");
      }
    });
  }

  declineReservation(reservationId: string){
    console.log(reservationId)
    this.bookingService.declineReservation(reservationId).subscribe();
  }
 }

