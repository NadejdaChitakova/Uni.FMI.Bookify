import { Component, Input } from '@angular/core';
import { Apartment } from '../../types/apartment';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { FileUploadModule } from 'primeng/fileupload';
import { ImageModule } from 'primeng/image';
import { ToastModule } from 'primeng/toast';
import { CommonModule } from '@angular/common';
import { ApartmentImageComponent } from '../apartment-image/apartment-image.component';
import { ApartmentService } from '../../services/apartment.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-apartment',
  standalone: true,
  imports: [FormsModule,
    InputTextModule,
    ButtonModule,
    InputTextareaModule,
    FileUploadModule,
    ImageModule,
    ToastModule,
    CommonModule,
    ApartmentImageComponent],
  templateUrl: './view-apartment.component.html',
  styleUrl: './view-apartment.component.css'
})
export class ViewApartmentComponent {
  @Input() id!: string;
  apartment: Apartment = {address : {city: "", street: ""}} as Apartment;

  constructor(private apartmentService: ApartmentService,
    private route: ActivatedRoute,
  ){}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
        this.apartmentService.getApartments(id)
        .subscribe(apartment =>  {
          this.apartment = apartment
          console.log(apartment)
    });
    }
  }
}
