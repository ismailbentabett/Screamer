import { Component } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';

@Component({
  selector: 'app-stories-carousel',
  templateUrl: './stories-carousel.component.html',
  styleUrls: ['./stories-carousel.component.scss'],
})
export class StoriesCarouselComponent {
  customOptions: OwlOptions = {
    loop: false,
    mouseDrag: true,
    touchDrag: true,
    pullDrag: true,
    dots: false,
    navSpeed: 700,
    navText: ['', ''],
    nav: false,
    margin: 0,
    stagePadding: 0,
  };
}
