import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ModalService {
  public isOpen: boolean = false;
  constructor(

  ) {}
  openPopup() {
    this.isOpen = true;
  }

  closePopup() {
    this.isOpen = false;
  }



}
