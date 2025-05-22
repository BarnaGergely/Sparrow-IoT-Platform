import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { authGuard } from './shared/guards/auth.guard';
import { DevicesComponent } from './pages/devices/devices.component';
import { HomePublicComponent } from './pages/home-public/home-public.component';
import { DashboardsComponent } from './pages/dashboards/dashboards.component';
import { DeviceComponent } from './pages/device/device.component';
import { SensorComponent } from './pages/sensor/sensor.component';

const routes: Routes = [
  {
    path: '',
    canActivate: [authGuard],
    children: [
      { path: '', component: HomeComponent },
      { path: 'devices', component: DevicesComponent },
      { path: 'devices/:id', component: DeviceComponent },
      { path: 'dashboards', component: DashboardsComponent },
      { path: 'devices/:deviceId/:sensorId', component: SensorComponent },
    ]
  },
  { path: '', component: HomePublicComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  //{ path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
