import { AuthService } from './../../services/auth.service';
import { MenubarModule } from 'primeng/menubar';
import { Component, OnInit } from '@angular/core';
import { MenuItem, MenuItemCommandEvent } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'header',
  standalone: true,
  imports: [
    MenubarModule,
    ButtonModule,
    CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})

export class HeaderComponent implements OnInit {
  items: MenuItem[] | undefined;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {

    this.items = [
      {
        label: 'Имоти',
        icon: 'pi pi-fw pi-plus',
        routerLink: "/"
      }
    ]
    if(!this.authService.isLoggedIn()){
      this.items.push(
        {
          label: 'Влизане в профила',
          icon: 'pi pi-fw pi-plus',
          routerLink: "login"
        })
        this.items.push({
          label: 'Регистрация',
          icon: 'pi pi-fw pi-plus',
          routerLink: "registration"
        })
    }

    if(this.isLoggedIn()){
      this.items.push(
        {
          label: 'Моите обяви',
          icon: 'pi pi-fw pi-plus',
          routerLink: 'my-apartments'
        }
      )
    }

    if(this.authService.isLoggedIn()){
      this.items.push(
        {
          label: 'Моите резервации',
          icon: 'pi pi-fw pi-plus',
          routerLink: 'my-reservations'
        }
      )
    }

    if(this.authService.isLoggedIn()){
      this.items.push(
        {
          label: 'Изход',
          icon: 'pi pi-fw pi-plus',
          command: () => this.authService.logout()

        })
    }
  }

  isLoggedIn(){
    var token = this.authService.decodeToken();
    return this.authService.isLoggedIn() && token != null && token.role == "Admin";

  }
}


