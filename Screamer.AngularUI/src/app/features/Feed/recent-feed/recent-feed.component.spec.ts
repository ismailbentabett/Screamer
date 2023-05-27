import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecentFeedComponent } from './recent-feed.component';

describe('RecentFeedComponent', () => {
  let component: RecentFeedComponent;
  let fixture: ComponentFixture<RecentFeedComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RecentFeedComponent]
    });
    fixture = TestBed.createComponent(RecentFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
