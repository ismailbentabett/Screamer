import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommentDropDownComponent } from './comment-drop-down.component';

describe('CommentDropDownComponent', () => {
  let component: CommentDropDownComponent;
  let fixture: ComponentFixture<CommentDropDownComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CommentDropDownComponent]
    });
    fixture = TestBed.createComponent(CommentDropDownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
