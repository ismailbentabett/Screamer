import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component } from '@angular/core';

@Component({
  selector: 'app-reaction-button',
  templateUrl: './reaction-button.component.html',
  styleUrls: ['./reaction-button.component.scss'],
  animations: [
    trigger('dropdownAnimation', [
      state('open', style({
        transform: 'opacity-100 scale-100',
        opacity: 1,
      })),
      state('closed', style({
        transform: 'opacity-0 scale-95',
        opacity: 0,
      })),
      transition('closed => open', animate('100ms ease-out')),
      transition('open => closed', animate('75ms ease-in')),
    ]),
  ],
})
export class ReactionButtonComponent {
  isOpen = false;

  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }
}
