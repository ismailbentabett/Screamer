import { Component } from '@angular/core';
import { StoryService } from 'src/app/core/services/story.service';

@Component({
  selector: 'app-floating-action-button',
  templateUrl: './floating-action-button.component.html',
  styleUrls: ['./floating-action-button.component.scss'],
})
export class FloatingActionButtonComponent {

  constructor(private storyService: StoryService) {}
  openStoryModal() {
    this.storyService.openPopup();
  }
}
