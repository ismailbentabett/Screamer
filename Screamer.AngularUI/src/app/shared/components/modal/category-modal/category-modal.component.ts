import { Component } from '@angular/core';
import { CategoryService } from 'src/app/core/services/category.service';
import { PostService } from 'src/app/core/services/post.service';
import { SearchService } from 'src/app/core/services/search.service';

@Component({
  selector: 'app-category-modal',
  templateUrl: './category-modal.component.html',
  styleUrls: ['./category-modal.component.scss'],
})
export class CategoryModalComponent {
  constructor(
    public postService: PostService,

    public categoryService: CategoryService
  ) {}

  searchCategories(): void {
    this.categoryService.searchResults = this.categoryService.categories.filter(
      (category) =>
        category
          .toLowerCase()
          .includes(this.categoryService.searchTerm.toLowerCase()) &&
        !this.categoryService.addedCategories.includes(category) &&
        this.categoryService.searchTerm.length >= 2
    );
  }

  addCategory(category: string): void {
    if (!this.categoryService.addedCategories.includes(category)) {
      this.categoryService.addedCategories.push(category);
    }
    //filter search results
    this.categoryService.searchResults =
      this.categoryService.searchResults.filter(
        (result) => result !== category
      );
  }

  removeCategory(category: string): void {
    this.categoryService.addedCategories =
      this.categoryService.addedCategories.filter(
        (result) => result !== category
      );
    //filter search results
    this.categoryService.searchResults.push(category);
  }

  openPopup() {
    this.postService.openCategoryPopup();
  }

  closePopup() {
    this.postService.closeCategoryPopup();
  }
}
