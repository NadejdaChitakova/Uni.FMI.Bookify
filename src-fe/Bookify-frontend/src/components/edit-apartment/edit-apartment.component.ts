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

@Component({
    selector: 'app-edit-apartment',
    standalone: true,
    templateUrl: './edit-apartment.component.html',
    styleUrl: './edit-apartment.component.css',
    imports: [FormsModule,
        InputTextModule,
        ButtonModule,
        InputTextareaModule,
        FileUploadModule,
        ImageModule,
        ToastModule,
        CommonModule, ApartmentImageComponent]
})

export class EditApartmentComponent implements OnInit
{
  apartment: Apartment = {address : {city: "", street: ""}} as Apartment;
  updatedApartment: UpdateApartmentRequest = {} as UpdateApartmentRequest;
  amenitiesId: string[] = []
  files! : File[] | null
  ids: string[] = [];

  constructor(private route: ActivatedRoute,
    private apartmentService: ApartmentService){
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
        this.apartmentService.getApartments(id)
        .subscribe(apartment =>  {
          this.apartment = apartment
          this.files = this.convertByteArrayToFile(this.apartment.id)
    });
    }
  }

  onSubmit() {
    console.log(this.apartment)
    console.log(this.updatedApartment)
    this.amenitiesId = this.apartment.amenities.map(({ id }) => id);

    this.updatedApartment.id = this.apartment.id;
    this.updatedApartment.name = this.apartment.name;
    this.updatedApartment.description = this.apartment.description;
    this.updatedApartment.street = this.apartment.address.street;
    this.updatedApartment.city = this.apartment.address.city;
    this.updatedApartment.cleaningFee = this.apartment.cleaningFee;
    this.updatedApartment.price = this.apartment.price;
    this.updatedApartment.amenitiesId = [] = this.amenitiesId;
    this.updatedApartment.countryId = '2a017b91-4a3f-4e11-b612-7bdbfd12856e'
    this.updatedApartment.images = this.ids;

    this.apartmentService.update(this.updatedApartment).subscribe();
  }

  onImageUpload(event: FileSelectEvent) {
    console.log(event)

    const formData = new FormData();

      for (let i = 0; i < event.files.length; i++) {
        const file = event.files[i];
          formData.append('images[]', file, file.name);
      }

    this.apartmentService.uploadImage(formData)
      .subscribe({
        next: (data) => {
          this.ids = data;
          console.log(this.ids);
        },
        error: (error) => {
          console.log(error, "test");
        }
      });
  }

  convertByteArrayToFile(apartmetId : string) : any[]{
    const imagesUrl: any[] = [];

    // for (let i = 0; i < apartmetnImages.length; i++) {

    //   const byteArray = apartmetnImages[i].content;
    //   console.log(byteArray)
    //   const blob = new Blob( [byteArray], {type: apartmetnImages[i].extension});

    //   const fileName = "image";
    //   const file = new File( [blob], fileName, {type : blob.type} )

    //   images.push(file);

    //   console.log(file)

    //   // FileReader()
    // }

    this.apartmentService.downloadApartmentImages(apartmetId)
      .subscribe();

    return imagesUrl;
  }
}
