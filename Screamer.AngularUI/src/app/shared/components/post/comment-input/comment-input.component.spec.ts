import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommentInputComponent } from './comment-input.component';

describe('CommentInputComponent', () => {
  let component: CommentInputComponent;
  let fixture: ComponentFixture<CommentInputComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CommentInputComponent]
    });
    fixture = TestBed.createComponent(CommentInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
