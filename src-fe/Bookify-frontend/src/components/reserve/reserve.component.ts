import { DateRange } from './../../types/dateRange';
import { Component, Input } from '@angular/core';
import { PanelModule } from 'primeng/panel';
import { FormsModule } from '@angular/forms';
import { CalendarModule, CalendarMonthChangeEvent } from 'primeng/calendar';
import { CommonModule, DatePipe } from '@angular/common';
import { ApartmentService } from '../../services/apartment.service';
import { GetUnavailableDate } from '../../types/getUnavailableDate';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Button, ButtonModule } from 'primeng/button';
import { ReserveRequest } from '../../types/ReserveRequest';
import { BookingService } from '../../services/booking.service';

@Component({
  selector: 'app-reserve',
  standalone: true,
  imports: [
    PanelModule,
    FormsModule,
    CalendarModule,
    CommonModule,
    RouterModule,
    ButtonModule,
    DatePipe,
  ],
  templateUrl: './reserve.component.html',
  styleUrl: './reserve.component.css'
})
export class ReserveComponent {
  apartmentId : string  = "";
  currentDate = new Date();
  rangeDates: Date[] = [];
  dates: Date[] = [];
  request: GetUnavailableDate = {apartmentId: this.apartmentId, month: 0, year: 0}
  pricePerNight: number = 0;
  cleaningFee: number = 0;

  constructor(private apartmentService: ApartmentService,
              private bookingService: BookingService,
              private router: ActivatedRoute,
              private route: Router){}

    ngOnInit(){
      let todat = new Date;
      this.apartmentId = this.router.snapshot.paramMap.get('id') ?? "";
      this.request.apartmentId = this.apartmentId;
      this.request.month = this.currentDate.getMonth();
      this.request.year = this.currentDate.getFullYear();

      this.apartmentService.getApartments(this.apartmentId).subscribe({
        next: (data) =>
        {
          this.pricePerNight = data.price;
          this.cleaningFee = data.cleaningFee;
        }
      })

      this.apartmentService.getUnavailablePeriods(this.request).subscribe
        ({
          next: (data) => {
            this.dates = this.convertToDate(data);
            console.log(this.dates);
          },
          error: (error) => {
            console.log(error, "test");
          }
        });
    }

  onMonthChange(event : CalendarMonthChangeEvent){
    this.request.month = event.month ?? 0;
    this.request.year = event.year ?? 0;

    this.apartmentService.getUnavailablePeriods(this.request).subscribe
    ({
      next: (data) => {
        this.dates = this.convertToDate(data);
        console.log(this.dates)
      },
      error: (error) => {
        console.log(error, "test");
      }
    });
  }

  reserve(){
    let request: ReserveRequest = {apartmentId: this.apartmentId, cleaningFee: this.cleaningFee,
      durationStart: this.rangeDates[0].toISOString(),
       durationEnd: this.rangeDates[1].toISOString(),
       priceForPeriod: this.rangeDates.length * this.pricePerNight,
        totalPrice: (this.rangeDates.length * this.pricePerNight) + this.cleaningFee};

      this.bookingService.bookApartment(request).subscribe();

      this.route.navigate(['/'])
    }

    convertToDate(dates: string[]): Date[] {
      return dates.map(d=> new Date(d));
    }
  }
