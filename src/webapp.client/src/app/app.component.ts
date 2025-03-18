import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MenuComponent } from "./shared/components/menu/menu.component";



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  imports: [RouterOutlet, MenuComponent]
})
export class AppComponent {


  title = 'webapp.client'; // TODO:
}
