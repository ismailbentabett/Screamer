import { Component } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { StoryService } from 'src/app/core/services/story.service';

@Component({
  selector: 'app-stories-carousel',
  templateUrl: './stories-carousel.component.html',
  styleUrls: ['./stories-carousel.component.scss'],
})
export class StoriesCarouselComponent {

  /**
   *
   */
  constructor(

    public storyService : StoryService
  ) {

  }

  openModal() {
    this.storyService.openPopup();
  }

}
