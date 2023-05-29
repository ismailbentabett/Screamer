import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss'],
})
export class SettingsComponent {
  constructor(private router: Router) {}

  SettingTabsStyle(route: string) {
    const isActive =
      this.router.isActive(route, false) || this.router.isActive(route, true);

    return isActive
      ? 'bg-dodger-blue-50 border-dodger-blue-500 text-dodger-blue-700 hover:bg-dodger-blue-50 hover:text-dodger-blue-700 group border-l-4 px-3 py-2 flex items-center text-sm font-medium'
      : 'border-transparent text-gray-900 hover:bg-gray-50 hover:text-gray-900 group border-l-4 px-3 py-2 flex items-center text-sm font-medium';
  }
  iconStyle(route: string) {
    const isActive =
      this.router.isActive(route, false) || this.router.isActive(route, true);

    return isActive
      ? 'text-dodger-blue-500 group-hover:text-dodger-blue-500 flex-shrink-0 -ml-1 mr-3 h-6 w-6'
      : 'text-gray-400 group-hover:text-gray-500 flex-shrink-0 -ml-1 mr-3 h-6 w-6';
  }
}
