import { Routes, RouterModule } from '@angular/router';
import { ApartmentComponent } from '../components/apartment/apartment.component';
import { EditApartmentComponent } from '../components/edit-apartment/edit-apartment.component';
import { ListApartmentsComponent } from '../components/list-apartments/list-apartments.component';
import { ViewApartmentComponent } from '../components/view-apartment/view-apartment.component';
import { AddApartmentComponent } from '../components/add-apartment/add-apartment.component';

export const routes: Routes = [
   { path: '', component: ListApartmentsComponent },
   { path: 'apartments/edit/:id', component: EditApartmentComponent },
   { path: 'apartments/view/:id', component: ViewApartmentComponent },
   { path: 'apartments/add', component: AddApartmentComponent}
];

export class AppRoutingModule { }
