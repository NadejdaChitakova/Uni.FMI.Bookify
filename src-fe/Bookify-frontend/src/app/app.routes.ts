import { Routes, RouterModule } from '@angular/router';
import { ApartmentComponent } from '../components/apartment/apartment.component';
import { EditApartmentComponent } from '../components/edit-apartment/edit-apartment.component';
import { ListApartmentsComponent } from '../components/list-apartments/list-apartments.component';

export const routes: Routes = [
   //{ path: '', component: ListApartmentsComponent },
   { path: 'apartments/edit/:id', component: EditApartmentComponent }
];

export class AppRoutingModule { }
