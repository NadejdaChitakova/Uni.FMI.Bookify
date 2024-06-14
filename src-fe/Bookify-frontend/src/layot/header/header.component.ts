import { AuthService } from './../../services/auth.service';
import { MenubarModule } from 'primeng/menubar';
import { Component, OnInit } from '@angular/core';
import { MenuItem, MenuItemCommandEvent } from 'primeng/api';

@Component({
  selector: 'header',
  standalone: true,
  imports: [
    MenubarModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})

export class HeaderComponent implements OnInit {
  items: MenuItem[] | undefined;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.items = [
      {
        label: 'Home',
        icon: 'pi pi-fw pi-plus',
      },
      {
        label: 'Apartments',
        icon: 'pi pi-fw pi-plus',
        routerLink: "/"
      }
    ]
    if(!this.authService.isLoggedIn()){
      this.items.push(
        {
          label: 'Login',
          icon: 'pi pi-fw pi-plus',
          routerLink: "login"
        })
        this.items.push({
          label: 'Registration',
          icon: 'pi pi-fw pi-plus',
          routerLink: "registration"
        })
    }

    if(this.authService.isLoggedIn()){
      this.items.push(
        {
          label: 'Logout',
          icon: 'pi pi-fw pi-plus',
          command: () => this.authService.logout()

        })
    }
  }
}


