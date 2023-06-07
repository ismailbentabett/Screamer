import { Component } from '@angular/core';

@Component({
  selector: 'app-comment-drop-down',
  templateUrl: './comment-drop-down.component.html',
  styleUrls: ['./comment-drop-down.component.scss']
})
export class CommentDropDownComponent {
  isOpen :  boolean = false;
  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }
}
