import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ModalService } from 'src/app/core/services/modal.service';
import { NotificationService } from 'src/app/core/services/notification.service';
@Component({
  selector: 'app-notification-dropdown',
  templateUrl: './notification-dropdown.component.html',
  styleUrls: ['./notification-dropdown.component.scss'],

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
export class NotificationDropDownComponent {
  constructor(
    public notificationService: NotificationService,
    public router: Router
  ) {}
  isOpen: boolean = false;
  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }

  openPopup() {
    this.isOpen = true;
    this.notificationService.openPopup();
  }
  closePopup() {
    this.notificationService.closePopup();
    this.isOpen = false;
  }

  IconsStyle(route: string): string {
    const isActive =
      this.router.isActive(route, false) || this.router.isActive(route, true);

    return isActive
      ? 'ml-auto flex-shrink-0 bg-white rounded-full p-1 text-gray-900 hover:text-gray-900 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-dodger-blue-500'
      : 'ml-auto flex-shrink-0 bg-white rounded-full p-1 text-gray-400 hover:text-gray-500 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-dodger-blue-500';
  }
}
