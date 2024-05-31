import { Component } from '@angular/core';
import { Address } from '../../types/address';
import { Apartment } from '../../types/apartment';
import { ApartmentService } from '../../services/apartment.service';
import { FileSelectEvent, FileUploadModule } from 'primeng/fileupload';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { CarouselModule } from 'primeng/carousel';
import { CalendarModule } from 'primeng/calendar';
import { ButtonModule } from 'primeng/button';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { ApartmentImageComponent } from '../apartment-image/apartment-image.component';

@Component({
  selector: 'app-add-apartment',
  standalone: true,
  imports: [FormsModule,
    FileUploadModule,
    CarouselModule,
    CalendarModule,
    ButtonModule,
    ApartmentImageComponent,
    InputTextModule,
    InputTextareaModule
  ],
  templateUrl: './add-apartment.component.html',
  styleUrl: './add-apartment.component.css'
})
export class AddApartmentComponent {
  address: Address = {country: "", street: "", city: ""};
  apartment!: Apartment ;
  ids: string[] = [];

 constructor(private apartmentService: ApartmentService) {}

 onSubmit(evet : Event){

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
