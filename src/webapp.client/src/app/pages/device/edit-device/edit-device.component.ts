import { Component, Input } from '@angular/core';
import { Device } from '../../../shared/models/device.model';

@Component({
  selector: 'app-edit-device',
  imports: [],
  templateUrl: './edit-device.component.html',
  styleUrl: './edit-device.component.scss'
})
export class EditDeviceComponent {
  @Input() device!: Device;
}
