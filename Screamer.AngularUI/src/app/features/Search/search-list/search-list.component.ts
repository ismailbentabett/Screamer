import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SearchService } from 'src/app/core/services/search.service';

@Component({
  selector: 'app-search-list',
  templateUrl: './search-list.component.html',
  styleUrls: ['./search-list.component.scss'],
})
export class SearchListComponent {
  constructor(private router: Router) {}

  LineStyle(route: string): string {
    const isActive =
      this.router.isActive(route, false) || this.router.isActive(route, true);

    return isActive
      ? 'bg-dodger-blue-500 absolute inset-x-0 bottom-0 h-0.5'
      : 'bg-transparent absolute inset-x-0 bottom-0 h-0.5';
  }
  TabStyle(route: string): string {
    const isActive =
      this.router.isActive(route, false) || this.router.isActive(route, true);

    return isActive
      ? 'text-gray-900 rounded-l-lg group relative min-w-0 flex-1 overflow-hidden bg-white py-4 px-6 text-sm font-medium text-center hover:bg-gray-50 focus:z-10'
      : 'text-gray-500 hover:text-gray-700 group relative min-w-0 flex-1 overflow-hidden bg-white py-4 px-6 text-sm font-medium text-center hover:bg-gray-50 focus:z-10';
  }
  navigateToRoute(route: string): void {
    this.router.navigateByUrl(route);
  }
}
