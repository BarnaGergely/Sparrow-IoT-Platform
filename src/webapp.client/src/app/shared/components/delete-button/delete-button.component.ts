import { Component, EventEmitter, inject, Output, signal, WritableSignal } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmDeleteModalComponent } from './confirm-delete-modal/confirm-delete-modal.component';

@Component({
  selector: 'app-delete-button',
  imports: [],
  templateUrl: './delete-button.component.html',
  styleUrl: './delete-button.component.scss'
})
export class DeleteButtonComponent {
  private modalService = inject(NgbModal);
  @Output() deleteEvent: EventEmitter<void> = new EventEmitter<void>();

  open() {
    this.modalService.open(ConfirmDeleteModalComponent).result.then(() => this.deleteEvent.emit());
  }
}
