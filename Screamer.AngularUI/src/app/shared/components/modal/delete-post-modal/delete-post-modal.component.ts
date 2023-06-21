import { Component } from '@angular/core';
import { ModalService } from 'src/app/core/services/modal.service';

@Component({
  selector: 'app-delete-post-modal',
  templateUrl: './delete-post-modal.component.html',
  styleUrls: ['./delete-post-modal.component.scss'],
})
export class DeletePostModalComponent {
  constructor(public modalService: ModalService) {}

  closeDeletePostPopup() {
    this.modalService.closeDeletePostPopup();
  }
}
