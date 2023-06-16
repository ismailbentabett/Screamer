import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookmarkFeedComponent } from './bookmark-feed.component';

describe('BookmarkFeedComponent', () => {
  let component: BookmarkFeedComponent;
  let fixture: ComponentFixture<BookmarkFeedComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BookmarkFeedComponent]
    });
    fixture = TestBed.createComponent(BookmarkFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
