
import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { HeaderComponent } from '../layot/header/header.component';
import { FooterComponent } from '../layot/footer/footer.component';
import { ListApartmentsComponent } from '../components/list-apartments/list-apartments.component';
import { HttpClientModule } from '@angular/common/http';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';  // Import NoopAnimationsModule
import { BrowserModule } from '@angular/platform-browser';
import { CalendarModule } from 'primeng/calendar';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
      RouterOutlet,
     HeaderComponent,
      FooterComponent,
      ListApartmentsComponent,
      HttpClientModule,
      RouterModule,
      CalendarModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Bookify';
}
