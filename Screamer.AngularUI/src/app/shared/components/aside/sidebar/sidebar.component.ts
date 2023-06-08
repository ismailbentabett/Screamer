import { Component } from '@angular/core';
import { PostService } from 'src/app/core/services/post.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent {
  MostUsedHashtags: any[] = [];
  MostUsedCategories: any[] = [];

  constructor(private postService: PostService) {}
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
}
