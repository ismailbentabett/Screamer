import { Component } from '@angular/core';
import { StoryService } from 'src/app/core/services/story.service';

@Component({
  selector: 'app-story-editor-fullscreen-modal',
  templateUrl: './story-editor-fullscreen-modal.component.html',
  styleUrls: ['./story-editor-fullscreen-modal.component.scss'],
})
export class StoryEditorFullscreenModalComponent {
  constructor(public storyService: StoryService) {}

  closeModal() {
    this.storyService.closePopup();
  }
}
