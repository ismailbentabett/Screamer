import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StoryService } from 'src/app/core/services/story.service';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.scss'],
})
export class FeedComponent {
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    public storyService: StoryService
  ) {}

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
