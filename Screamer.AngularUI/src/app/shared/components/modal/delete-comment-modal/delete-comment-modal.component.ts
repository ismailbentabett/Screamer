import { Component } from '@angular/core';
import { ModalService } from 'src/app/core/services/modal.service';

@Component({
  selector: 'app-delete-comment-modal',
  templateUrl: './delete-comment-modal.component.html',
  styleUrls: ['./delete-comment-modal.component.scss'],
})
export class DeleteCommentModalComponent {
  constructor(public modalService: ModalService) {}

  closeDeleteCommentPopup() {
    this.modalService.closeDeleteCommentPopup();
  }
  openDeleteCommentPopup() {
    this.modalService.openDeleteCommentPopup();
  }
}
