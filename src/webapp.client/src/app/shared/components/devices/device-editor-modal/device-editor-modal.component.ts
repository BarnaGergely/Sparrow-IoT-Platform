import { Component, computed, EventEmitter, inject, Input, OnInit, Output, signal, Signal, TemplateRef, WritableSignal } from '@angular/core';
import { Device } from '../../../models/device.model';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { DevicesService } from '../../../services/devices.service';
import { CommonModule } from '@angular/common';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-device-editor-modal',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './device-editor-modal.component.html',
  styleUrl: './device-editor-modal.component.scss'
})
export class DeviceEditorModalComponent {
  private formBuilder: FormBuilder = inject(FormBuilder);
  private devicesService: DevicesService = inject(DevicesService);
  private modalService = inject(NgbModal);

  @Input() device!: Device | undefined;
  @Output() changedEvent: EventEmitter<void> = new EventEmitter<void>();
  form = this.formBuilder.group({
    id: [0, []],
    name: ['', [Validators.required]],
  });
  title: string = 'Create Device';

  open(content: TemplateRef<any>) {
    if (this.device && this.isUpdate()) {
      this.title = 'Update Device';
      this.form.setValue({
        id: this.device.id,
        name: this.device.name,
      });
    } else {
      this.title = 'Create Device';
      this.form.setValue({
        id: 0,
        name: '',
      });
    }

    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }

  isUpdate(): boolean {
    return this.device !== undefined;
  }

  onSubmit(modal: any): void {
    if (this.form.invalid) {
      alert('Please fill in all fields correctly.');
      return;
    }

    const device = this.form.value as Device;

    if (this.isUpdate()) {
      this.devicesService.update(device).subscribe({
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
      this.devicesService.create(device).subscribe({
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
