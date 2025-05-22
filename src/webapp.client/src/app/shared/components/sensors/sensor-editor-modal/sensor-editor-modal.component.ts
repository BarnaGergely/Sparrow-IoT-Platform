import { Component, EventEmitter, inject, Input, Output, signal, TemplateRef } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SensorsService } from '../../../services/sensors.service';
import { MeasurementKind, Sensor } from '../../../models/sensor.model';
@Component({
  selector: 'app-sensor-editor-modal',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './sensor-editor-modal.component.html',
  styleUrl: './sensor-editor-modal.component.scss'
})
export class SensorEditorModalComponent {
  private formBuilder: FormBuilder = inject(FormBuilder);
  private sensorsService: SensorsService = inject(SensorsService);
  private modalService = inject(NgbModal);

  @Input() sensor!: Sensor | undefined;
  @Input() deviceId!: number;
  @Output() changedEvent: EventEmitter<void> = new EventEmitter<void>();
  form = this.formBuilder.group({
    id: [0, []],
    deviceId: [this.deviceId, [Validators.required]],
    name: ['', [Validators.required]],
    kind: [MeasurementKind.Temperature, [Validators.required]],
  });
  title: string = 'Create Sensor';

  measurementKindArray: { key: string; value: MeasurementKind }[] = Object.keys(MeasurementKind)
    .filter(key => isNaN(Number(key))) // Filter out numeric keys
    .map(key => ({ key, value: MeasurementKind[key as keyof typeof MeasurementKind] }));

  open(content: TemplateRef<any>) {

    if (this.sensor && this.isUpdate()) {
      if (this.sensor?.deviceId != this.deviceId) {
        console.error('Sensor does not belong to device: ');
        return;
      }

      this.form.setValue({
        id: this.sensor.id,
        deviceId: this.sensor.deviceId,
        name: this.sensor.name,
        kind: this.sensor.kind,
      });
      this.title = 'Edit Sensor';

    } else {
      this.form.setValue({
        id: 0,
        deviceId: this.deviceId,
        name: '',
        kind: 0,
      });
      this.title = 'Create Sensor';
    }

    this.modalService.open(content, { ariaLabelledBy: 'edit-sensor-modal' });
  }

  isUpdate(): boolean {
    return this.sensor !== undefined;
  }

  onSubmit(modal: any): void {
    if (this.form.invalid) {
      alert('Please fill in all fields correctly.');
      return;
    }

    const sensor = this.form.value as Sensor;
    console.log(sensor);

    if (this.isUpdate()) {
      this.sensorsService.update(sensor).subscribe({
        next: () => {
          this.changedEvent.emit();
          modal.close('Save click')
        },
        error: (error) => {
          alert('Error occurred while updating device.');
          console.error(error);
        },
      });
    } else {
      this.sensorsService.create(sensor).subscribe({
        next: () => {
          this.changedEvent.emit();
          modal.close('Save click')
        },
        error: (error) => {
          alert('Error occurred while creating device.');
          console.error(error);
        },
      });
    }
  }
}
