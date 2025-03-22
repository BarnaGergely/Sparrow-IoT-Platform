import { Component, inject, OnInit } from '@angular/core';
import { DevicesService } from '../../shared/services/devices.service';
import { Device } from '../../shared/models/device.model';
import { RouterLink } from '@angular/router';
import { NgStyle } from '@angular/common';
import { DeviceEditorModalComponent } from "../../shared/components/devices/device-editor-modal/device-editor-modal.component";

@Component({
  selector: 'app-devices',
  imports: [RouterLink, NgStyle, DeviceEditorModalComponent],
  templateUrl: './devices.component.html',
  styleUrl: './devices.component.scss'
})
export class DevicesComponent implements OnInit {
  private devicesService: DevicesService = inject(DevicesService);

  devices?: Device[];

  ngOnInit(): void {
    this.devicesService.getAll().subscribe((devices: Device[]) => {
      this.devices = devices;
    });
  }

  getStatusColor(status: Device): string {
    switch (status.status) {
      case 'success':
        return 'green';
      case 'warning':
        return 'yellow';
      case 'error':
        return 'red';
      default:
        return 'yellow';
    }
  }

  ondeviceChanged() {
    this.ngOnInit();
  }

  deleteDevice(device: Device) {
    this.devicesService.delete(device).subscribe(() => {
      this.ngOnInit();
    });
  }
}
