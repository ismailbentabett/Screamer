import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryFeedComponent } from './category-feed.component';

describe('CategoryFeedComponent', () => {
  let component: CategoryFeedComponent;
  let fixture: ComponentFixture<CategoryFeedComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CategoryFeedComponent]
    });
    fixture = TestBed.createComponent(CategoryFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
