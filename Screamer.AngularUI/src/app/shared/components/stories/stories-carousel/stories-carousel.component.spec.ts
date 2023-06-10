import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoriesCarouselComponent } from './stories-carousel.component';

describe('StoriesCarouselComponent', () => {
  let component: StoriesCarouselComponent;
  let fixture: ComponentFixture<StoriesCarouselComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StoriesCarouselComponent]
    });
    fixture = TestBed.createComponent(StoriesCarouselComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
