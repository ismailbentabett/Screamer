import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { Component } from '@angular/core';
import { ModalService } from 'src/app/core/services/modal.service';

@Component({
  selector: 'app-comment-drop-down',
  templateUrl: './comment-drop-down.component.html',
  styleUrls: ['./comment-drop-down.component.scss'],
  animations: [
    trigger('dropdownAnimation', [
      state(
        'open',
        style({
          transform: 'opacity-100 scale-100',
          opacity: 1,
        })
      ),
      state(
        'closed',
        style({
          transform: 'opacity-0 scale-95',
          opacity: 0,
        })
      ),
      transition('closed => open', animate('100ms ease-out')),
      transition('open => closed', animate('75ms ease-in')),
    ]),
  ],
})
export class CommentDropDownComponent {
  constructor(public modalService: ModalService) {}
  isOpen: boolean = false;
  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }

  closeDeleteCommentPopup() {
    this.modalService.closeDeleteCommentPopup();
  }
  openDeleteCommentPopup() {
    this.modalService.openDeleteCommentPopup();
    this.isOpen = false;
  }
}
