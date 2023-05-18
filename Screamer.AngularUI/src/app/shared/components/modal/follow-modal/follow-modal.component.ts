import { Component, Input } from '@angular/core';
import { ModalService } from 'src/app/core/services/modal.service';

@Component({
  selector: 'app-follow-modal',
  templateUrl: './follow-modal.component.html',
  styleUrls: ['./follow-modal.component.scss']
})
export class FollowModalComponent {

/**
 *
 */
constructor(public modalService : ModalService) {

}
  openPopup() {
    this.modalService.openPopup();

  }

  closePopup() {
    this.modalService.closePopup();

  }
}
