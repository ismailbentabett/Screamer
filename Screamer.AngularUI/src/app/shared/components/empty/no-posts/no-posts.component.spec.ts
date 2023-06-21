import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoPostsComponent } from './no-posts.component';

describe('NoPostsComponent', () => {
  let component: NoPostsComponent;
  let fixture: ComponentFixture<NoPostsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NoPostsComponent]
    });
    fixture = TestBed.createComponent(NoPostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
