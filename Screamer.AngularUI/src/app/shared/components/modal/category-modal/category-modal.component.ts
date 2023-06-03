import { Component } from '@angular/core';
import { PostService } from 'src/app/core/services/post.service';
import { SearchService } from 'src/app/core/services/search.service';

@Component({
  selector: 'app-category-modal',
  templateUrl: './category-modal.component.html',
  styleUrls: ['./category-modal.component.scss']
})
export class CategoryModalComponent {
  constructor(public postService: PostService) {}

  openPopup() {
    this.postService.openCategoryPopup();
  }

  closePopup() {
    this.postService.closeCategoryPopup();
  }
}
