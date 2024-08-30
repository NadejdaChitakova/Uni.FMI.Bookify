import { Routes, RouterModule } from '@angular/router';
import { ApartmentComponent } from '../components/apartment/apartment.component';
import { EditApartmentComponent } from '../components/edit-apartment/edit-apartment.component';
import { ListApartmentsComponent } from '../components/list-apartments/list-apartments.component';
import { ViewApartmentComponent } from '../components/view-apartment/view-apartment.component';
import { AddApartmentComponent } from '../components/add-apartment/add-apartment.component';
import { LoginComponent } from '../components/login/login.component';
import { RegistrationComponent } from '../components/registration/registration.component';
import { authGuard } from '../guards/auth.guard';
import { ReserveComponent } from '../components/reserve/reserve.component';
import { MyApartmentsComponent } from '../components/my-apartments/my-apartments.component';
import { MyReservationsComponent } from '../components/my-reservations/my-reservations.component';
import { ApartmentReservationsComponent } from '../components/apartment-reservations/apartment-reservations.component';

export const routes: Routes = [
   { path: '', component: ListApartmentsComponent},
   { path: 'apartments/edit/:id', component: EditApartmentComponent,canActivate: [authGuard] },
   { path: 'apartments/view/:id', component: ViewApartmentComponent },
   { path: 'apartments/add', component: AddApartmentComponent, canActivate: [authGuard]},
   { path: 'login', component: LoginComponent},
   { path: 'registration', component: RegistrationComponent},
   { path: 'app-reserve/:id', component: ReserveComponent},
   { path: 'my-apartments', component: MyApartmentsComponent},
   { path: 'my-reservations', component: MyReservationsComponent},
   { path: 'apartmentReservations/:id', component: ApartmentReservationsComponent}
];

export class AppRoutingModule { }
