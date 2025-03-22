import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sensor } from '../models/sensor.model';
import { environment } from '../../../environments/environment';
import { Device } from '../models/device.model';

@Injectable({
  providedIn: 'root'
})
export class SensorsService {
  private http: HttpClient = inject(HttpClient);

  apiUrl = environment.apiUrl + '/protected/sensors';

  getAll(): Observable<Sensor[]> {
    return this.http.get<Sensor[]>(this.apiUrl);
  }

  get(sensor: Sensor): Observable<Sensor> {
    return this.getById(sensor.id);
  }

  getById(id: number): Observable<Sensor> {
    return this.http.get<Sensor>(`${this.apiUrl}/${id}`);
  }

  getByDevice(device: Device): Observable<Sensor[]> {
    return this.getByDeviceId(device.id);
  }

  getByDeviceId(deviceId: number): Observable<Sensor[]> {
    return this.http.get<Sensor[]>(`${this.apiUrl}/device/${deviceId}`);
  }

  create(sensor: Sensor): Observable<void> {
    return this.http.post<void>(this.apiUrl, sensor);
  }

  update(sensor: Sensor): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${sensor.id}`, sensor);
  }

  delete(sensor: Sensor): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${sensor.id}`);
  }
}
