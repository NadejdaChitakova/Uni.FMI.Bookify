import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApartmentService } from '../../services/apartment.service';
import { Apartment } from '../../types/apartment';
import { FormsModule } from '@angular/forms';
import { UpdateApartmentRequest } from '../../types/UpdateApartmentRequest';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { FileSelectEvent, FileUploadModule } from 'primeng/fileupload';
import { ImageModule } from 'primeng/image';
import { ToastModule } from 'primeng/toast';
import { CommonModule } from '@angular/common';
import { ApartmentImageComponent } from '../apartment-image/apartment-image.component';
import { Router, RouterLink } from '@angular/router';
import { CalendarModule } from 'primeng/calendar';
import { InsertApartment } from '../../types/insertApartment';

@Component({
  selector: 'app-add-apartment',
  standalone: true,
  imports: [
    FormsModule,
    InputTextModule,
    ButtonModule,
    InputTextareaModule,
    FileUploadModule,
    ImageModule,
    ToastModule,
    CommonModule,
    ApartmentImageComponent,
    RouterLink,
    CalendarModule
  ],
  templateUrl: './add-apartment.component.html',
  styleUrl: './add-apartment.component.css'
})
export class AddApartmentComponent {
  apartment: Apartment = {address : {city: "", street: ""}} as Apartment;
  insertEntity: InsertApartment = {} as InsertApartment;
  ids: string[] = [];

 constructor(private apartmentService: ApartmentService) {}

 onSubmit(evet : Event){
  this.insertEntity.Name = this.apartment.name;
  this.insertEntity.Description = this.apartment.description;
  this.insertEntity.Price = this.apartment.price;
  this.insertEntity.CleaningFee = this.apartment.cleaningFee;
  this.insertEntity.ApartmentPhotosIds = this.ids;
  this.insertEntity.Address = { city: this.apartment.address.city, street: this.apartment.address.street, country: ''};
  console.log(this.insertEntity, "inserted entity")
  this.apartmentService.insert(this.insertEntity).subscribe();
 }

 onImageUpload(event: FileSelectEvent) {
  const formData = new FormData();

    for (let i = 0; i < event.files.length; i++) {
      const file = event.files[i];
        formData.append('images[]', file, file.name);
    }

  this.apartmentService.uploadImage(formData)
    .subscribe({
      next: (data) => {
        this.ids = [... this.ids, ...data];
        console.log(this.ids);
      },
      error: (error) => {
        console.log(error, "test");
      }
    });
}
}
