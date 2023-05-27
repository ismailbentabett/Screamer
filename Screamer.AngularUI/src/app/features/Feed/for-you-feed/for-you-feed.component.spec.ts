import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForYouFeedComponent } from './for-you-feed.component';

describe('ForYouFeedComponent', () => {
  let component: ForYouFeedComponent;
  let fixture: ComponentFixture<ForYouFeedComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ForYouFeedComponent]
    });
    fixture = TestBed.createComponent(ForYouFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
