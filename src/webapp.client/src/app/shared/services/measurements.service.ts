import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Measurement } from '../models/measurement.model';
import { environment } from '../../../environments/environment';
import { Sensor } from '../models/sensor.model';

@Injectable({
  providedIn: 'root'
})
export class MeasurementsService {
  private apiUrl = environment.apiUrl + '/protected/measurements';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Measurement[]> {
    return this.http.get<Measurement[]>(`${this.apiUrl}`);
  }

  get(measurement: Measurement): Observable<Measurement> {
    return this.getById(measurement.id);
  }

  getById(id: number): Observable<Measurement> {
    return this.http.get<Measurement>(`${this.apiUrl}/${id}`);
  }

  getBySensor(sensor: Sensor): Observable<Measurement[]> {
    return this.getBySensorId(sensor.id);
  }

  getBySensorId(sensorId: number): Observable<Measurement[]> {
    return this.http.get<Measurement[]>(`${this.apiUrl}/sensor/${sensorId}`);
  }

  create(measurement: Measurement): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}`, measurement);
  }

  update(id: number, measurement: Measurement): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, measurement);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
