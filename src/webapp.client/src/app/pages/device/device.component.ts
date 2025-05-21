import { Component, inject, Input, OnInit, signal, Signal } from '@angular/core';
import { Device } from '../../shared/models/device.model';
import { DevicesService } from '../../shared/services/devices.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { SensorsService } from '../../shared/services/sensors.service';
import { MeasurementKind, Sensor, measurementKindToString } from '../../shared/models/sensor.model';
import { DeviceEditorModalComponent } from "../../shared/components/devices/device-editor-modal/device-editor-modal.component";
import { SensorEditorComponent } from "./sensor-editor/sensor-editor.component";
import { DeleteButtonComponent } from "../../shared/components/delete-button/delete-button.component";
import { MeasurementsService } from '../../shared/services/measurements.service';

@Component({
  selector: 'app-device',
  imports: [RouterLink, DeviceEditorModalComponent, SensorEditorComponent, DeleteButtonComponent],
  templateUrl: './device.component.html',
  styleUrl: './device.component.scss'
})
export class DeviceComponent implements OnInit {
  private devicesService: DevicesService = inject(DevicesService);
  private sensorsService: SensorsService = inject(SensorsService);
  private measurementsService: MeasurementsService = inject(MeasurementsService);
  private route: ActivatedRoute = inject(ActivatedRoute);
  device?: Device;

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      if (!params.has('id'))
        throw new Error('No device id provided.');

      const id = params.get('id') as unknown as number;
      this.devicesService.getById(id).subscribe
        ((device: Device) => {
          this.device = device;
          this.sensorsService.getByDeviceId(device.id).subscribe((sensors: Sensor[]) => {
            device.sensors = sensors;

            device.sensors.forEach(sensor => {
              this.measurementsService.getBySensor(sensor).subscribe((measurement) => {
                sensor.measurements = measurement;
              });
            });
            
          });
        });
    });
  }

  onDeviceChanged(): void {
    this.ngOnInit();
  }

  onSensorChanged() {
    this.ngOnInit();
  }

  measurementKindToString(kind: MeasurementKind): string {
    return measurementKindToString(kind);
  }

  deleteDevice(device: Device) {
    throw new Error('Method not implemented.');
  }

  deleteSensor(sensor: Sensor): void {
    this.sensorsService.delete(sensor).subscribe(() => {
      this.ngOnInit();
    });
  }
}
