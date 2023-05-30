import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPostComponent } from './show-post.component';

describe('ShowPostComponent', () => {
  let component: ShowPostComponent;
  let fixture: ComponentFixture<ShowPostComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShowPostComponent]
    });
    fixture = TestBed.createComponent(ShowPostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
