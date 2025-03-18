import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { MenubarModule } from 'primeng/menubar';

@Component({
  selector: 'app-menu',
  imports: [CommonModule, MenubarModule],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})
export class MenuComponent implements OnInit {
  model: MenuItem[] = [];

  ngOnInit() {
    this.model = [
      {
        label: 'Home',
        icon: 'pi pi-fw pi-home',
        routerLink: ['/']
      },
      {
        label: 'Dashboards',
        icon: 'pi pi-fw pi-home',
        routerLink: ['/dashboards']
      },
      {
        label: 'Devices',
        icon: 'pi pi-fw pi-shopping-cart',
        routerLink: ['/devices']
      },
      {
        label: 'Profile',
        icon: 'pi pi-fw pi-info',
        routerLink: ['/login']
      }
    ];
  }
}
