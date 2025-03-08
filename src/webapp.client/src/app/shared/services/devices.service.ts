import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { Device } from '../models/device.model';

@Injectable({
  providedIn: 'root'
})
export class DevicesService {
  http: HttpClient = inject(HttpClient);

  private apiUrl = environment.apiUrl + '/protected/devices';

  getAll(): Observable<Device[]> {
    return this.http.get<Device[]>(this.apiUrl);
  }

  get(device: Device): Observable<Device> {
    return this.getById(device.id);

  };

  getById(id: number): Observable<Device> {
    return this.http.get<Device>(`${this.apiUrl}/${id}`);
  }

  create(device: Device): Observable<void> {
    return this.http.post<void>(this.apiUrl, device);
  }

  update(device: Device): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${device.id}`, device);
  }

  delete(device: Device): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${device.id}`);
  }

}
