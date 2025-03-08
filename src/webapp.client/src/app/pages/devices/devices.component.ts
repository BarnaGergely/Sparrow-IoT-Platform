import { Component, inject, OnInit } from '@angular/core';
import { DevicesService } from '../../shared/services/devices.service';
import { JsonPipe } from '@angular/common';
import { Device } from '../../shared/models/device.model';
import { SensorsService } from '../../shared/services/sensors.service';
import { MeasurementsService } from '../../shared/services/measurements.service';

@Component({
  selector: 'app-devices',
  imports: [JsonPipe],
  templateUrl: './devices.component.html',
  styleUrl: './devices.component.scss'
})
export class DevicesComponent implements OnInit {
  private devicesService: DevicesService = inject(DevicesService);
  private sensorsService: SensorsService = inject(SensorsService);
  private measurementsService: MeasurementsService = inject(MeasurementsService);

  devices?: Device[];

  ngOnInit(): void {
    this.devicesService.getAll().subscribe((devices: Device[]) => {
      this.devices = devices;
      this.devices.forEach(device => {
        this.sensorsService.getByDeviceId(device.id).subscribe(sensors => {
          device.sensors = sensors;
          sensors.forEach(sensor => {
            this.measurementsService.getBySensorId(sensor.id).subscribe(measurements => {
              sensor.measurements = measurements;
            });
          });
        });
      });
    });
  }

}
