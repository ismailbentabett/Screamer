import { Component } from '@angular/core';
import { PostService } from 'src/app/core/services/post.service';
import { SearchService } from 'src/app/core/services/search.service';

@Component({
  selector: 'app-tag-modal',
  templateUrl: './tag-modal.component.html',
  styleUrls: ['./tag-modal.component.scss'],
})
export class TagModalComponent {
  constructor(public postService: PostService) {}

  openPopup() {
    this.postService.openTagPopup();
  }

  closePopup() {
    this.postService.CloseTagPopup();
  }
}
