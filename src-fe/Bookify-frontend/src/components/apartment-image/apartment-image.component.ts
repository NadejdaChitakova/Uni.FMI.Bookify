import { CommonModule } from '@angular/common';
import { ApartmentService } from './../../services/apartment.service';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-apartment-image',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './apartment-image.component.html',
  styleUrl: './apartment-image.component.css'
})
export class ApartmentImageComponent {
  @Input() apartmentImageId!: string;
  @Input() isEdit : boolean = false;
  constructor( private apartmentService: ApartmentService){}

  DeletePhoto(apartmentImageId: string){
    this.apartmentService.deletePhoto(apartmentImageId).subscribe();
  }
}
