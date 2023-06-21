import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ModalService {
  public isOpen: boolean = false;
  public isDeletePostOpen: boolean = false;
  public isDeleteCommentOpen: boolean = false;

  constructor() {}
  openPopup() {
    this.isOpen = true;
  }

  closeDeleteCommentPopup() {
    this.isDeleteCommentOpen = false;
  }
  openDeleteCommentPopup() {
    this.isDeleteCommentOpen = true;
  }

  closePopup() {
    this.isOpen = false;
  }
  openDeletePostPopup() {
    this.isDeletePostOpen = true;
  }

  closeDeletePostPopup() {
    this.isDeletePostOpen = false;
  }

}
