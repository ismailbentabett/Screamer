import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteCommentModalComponent } from './delete-comment-modal.component';

describe('DeleteCommentModalComponent', () => {
  let component: DeleteCommentModalComponent;
  let fixture: ComponentFixture<DeleteCommentModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteCommentModalComponent]
    });
    fixture = TestBed.createComponent(DeleteCommentModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
