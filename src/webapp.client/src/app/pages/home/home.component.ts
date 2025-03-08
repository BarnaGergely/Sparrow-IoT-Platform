import { Component } from '@angular/core';
import { WeatherComponent } from "./weather/weather.component";

@Component({
  selector: 'app-home',
  imports: [WeatherComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

}
