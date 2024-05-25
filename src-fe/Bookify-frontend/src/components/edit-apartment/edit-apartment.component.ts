import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApartmentService } from '../../services/apartment.service';
import { Apartment } from '../../types/apartment';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-edit-apartment',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './edit-apartment.component.html',
  styleUrl: './edit-apartment.component.css'
})
export class EditApartmentComponent implements OnInit
{
  apartment: Apartment = {} as Apartment;

  constructor(private route: ActivatedRoute,
    private apartmentService: ApartmentService){
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
        this.apartmentService.getApartments(id)
        .subscribe(apartment => this.apartment = apartment);
    }
  }
  onSubmit() {}
}
