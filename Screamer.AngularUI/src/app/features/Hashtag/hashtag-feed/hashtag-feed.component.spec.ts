import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HashtagFeedComponent } from './hashtag-feed.component';

describe('HashtagFeedComponent', () => {
  let component: HashtagFeedComponent;
  let fixture: ComponentFixture<HashtagFeedComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HashtagFeedComponent]
    });
    fixture = TestBed.createComponent(HashtagFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
