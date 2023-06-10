import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletePostModalComponent } from './delete-post-modal.component';

describe('DeletePostModalComponent', () => {
  let component: DeletePostModalComponent;
  let fixture: ComponentFixture<DeletePostModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeletePostModalComponent]
    });
    fixture = TestBed.createComponent(DeletePostModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
