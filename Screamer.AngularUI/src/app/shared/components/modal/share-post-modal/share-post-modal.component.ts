import { Component, Input } from '@angular/core';
import { PostService } from 'src/app/core/services/post.service';

@Component({
  selector: 'app-share-post-modal',
  templateUrl: './share-post-modal.component.html',
  styleUrls: ['./share-post-modal.component.scss'],
})
export class SharePostModalComponent {
  @Input()
  url: string | null = null;
  @Input()
  description: string | null = null;
  @Input()
  image: string | null = null;
  @Input()
  title: string | null = null;

  constructor(public postService: PostService) {}

  openPopup() {
    this.postService.openSharePopup();
  }

  closePopup() {
    this.postService.CloseSharePopup();
  }
}
