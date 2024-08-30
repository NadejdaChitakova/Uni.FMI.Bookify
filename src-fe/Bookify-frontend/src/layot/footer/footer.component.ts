import { Component } from '@angular/core';
import { Button, ButtonModule } from 'primeng/button';
import { Panel, PanelModule } from 'primeng/panel';

@Component({
  selector: 'footer',
  standalone: true,
  imports: [
    PanelModule,
    ButtonModule
  ],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css'
})
export class FooterComponent {
  currentYear = new Date().getFullYear();

}
