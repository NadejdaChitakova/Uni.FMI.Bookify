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

}
