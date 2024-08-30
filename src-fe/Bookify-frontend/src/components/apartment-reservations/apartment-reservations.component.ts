import { Component } from '@angular/core';
import { ActivatedRoute, Route } from '@angular/router';
import { ApartmentService } from '../../services/apartment.service';
import { GetMyApartmentReservations } from '../../types/getMyApartmentReservations';
import { PanelModule } from 'primeng/panel';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-apartment-reservations',
  standalone: true,
  imports: [
    PanelModule,
    TableModule
  ],
  templateUrl: './apartment-reservations.component.html',
  styleUrl: './apartment-reservations.component.css'
})
export class ApartmentReservationsComponent {
 reservations: GetMyApartmentReservations = { apartmentId: '', apartmentName: '',
    entireProfit: 0, reservations: []
 };

  constructor(private route: ActivatedRoute,
    private apartmentService: ApartmentService
  ){}

  ngOnInit(){
    const id = this.route.snapshot.paramMap.get('id') ?? '';

    this.apartmentService.getmyApartmentReservations(id).subscribe({
      next: (data) => {
        this.reservations = data;
        console.log(this.reservations)
      }
    });
  }
}
