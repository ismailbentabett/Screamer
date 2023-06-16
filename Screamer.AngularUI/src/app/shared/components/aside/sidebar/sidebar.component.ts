import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PostService } from 'src/app/core/services/post.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent {
  MostUsedHashtags: any[] = [];
  MostUsedCategories: any[] = [];

  constructor(
    private postService: PostService,
    private router: Router,
    private route: ActivatedRoute
  ) {}
  ngOnInit(): void {
    this.getMostUsedHashtags();
    this.getMostUsedCategories();
  }
  getMostUsedHashtags() {
    this.postService.getMostUsedHashtags().subscribe((response: any) => {
      this.MostUsedHashtags = response.map((x: any) => x.hashtag.name);
    });
  }
  getMostUsedCategories() {
    this.postService.getMostUsedCategories().subscribe((response: any) => {
      this.MostUsedCategories = response.map((x: any) => x.category.name);
    });
  }
  TabStyle(route: string): string {
    const isActive =
      this.router.isActive(route, false) || this.router.isActive(route, true);

    return isActive
      ? 'bg-gray-200 text-gray-900 group flex items-center px-3 py-2 text-sm font-medium rounded-md'
      : 'text-gray-600 hover:bg-gray-50 group flex items-center px-3 py-2 text-sm font-medium rounded-md';
  }

  categoryTabStyle(route: string): string {
    const isActive =
      this.router.isActive(route, false) || this.router.isActive(route, true);

    return isActive
      ? 'group flex items-center px-3 py-2 text-sm font-medium bg-gray-200 text-gray-900 rounded-md hover:text-gray-900 hover:bg-gray-50'
      : 'group flex items-center px-3 py-2 text-sm font-medium text-gray-600 rounded-md hover:text-gray-900 hover:bg-gray-50';
  }


  HashTagTabStyle(hashtag: string): string {
    let hashRoute = `/v/hashtag/${hashtag}`
    const isActive =
      this.router.isActive(hashRoute, false) || this.router.isActive(hashRoute, true);

    return isActive
      ? 'group flex items-center px-3 py-2 text-sm font-medium bg-gray-200 text-gray-900 rounded-md hover:text-gray-900 hover:bg-gray-50'
      : 'group flex items-center px-3 py-2 text-sm font-medium text-gray-600 rounded-md hover:text-gray-900 hover:bg-gray-50';
  }
}
