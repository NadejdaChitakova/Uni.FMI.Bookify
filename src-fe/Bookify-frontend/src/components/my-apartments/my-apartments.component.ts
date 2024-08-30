import { Component } from '@angular/core';
import { Button, ButtonModule } from 'primeng/button';
import { PanelModule } from 'primeng/panel';
import { TableModule } from 'primeng/table';
import { ApartmentService } from '../../services/apartment.service';
import { GetMyApartments } from '../../types/getMyApartments';
import { Router, RouteReuseStrategy, RouterModule  } from '@angular/router';

@Component({
  selector: 'app-my-apartments',
  standalone: true,
  imports: [
    ButtonModule,
    PanelModule,
    TableModule,
    RouterModule
  ],
  templateUrl: './my-apartments.component.html',
  styleUrl: './my-apartments.component.css'
})
export class MyApartmentsComponent {

  myApartments: GetMyApartments[] = [];

  constructor(private apartmentService: ApartmentService,
              private router: Router
  ){}

  ngOnInit(){
    this.apartmentService.getMyApartments().subscribe({
      next: (data) => {
        this.myApartments = data;
      }
    });
  }

  viewApartment(apartmentId: number){
    this.router.navigate(['/apartments/view/', apartmentId]);
  }

  editApartment(apartmentId: number){
    this.router.navigate(['/apartments/edit/', apartmentId]);
  }

  viewReservations(apartmentId: number){
    this.router.navigate(['apartmentReservations/', apartmentId]);
  }
}
