import { ApartmentService } from './../../services/apartment.service';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-apartment-image',
  standalone: true,
  imports: [],
  templateUrl: './apartment-image.component.html',
  styleUrl: './apartment-image.component.css'
})
export class ApartmentImageComponent {
  @Input() apartmentImageId!: string;

  constructor( private apartmentService: ApartmentService){}

  DeletePhoto(apartmentImageId: string){
    this.apartmentService.deletePhoto(apartmentImageId).subscribe();
  }
}
