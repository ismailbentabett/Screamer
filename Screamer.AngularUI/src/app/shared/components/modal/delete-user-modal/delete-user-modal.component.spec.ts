import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteUserModalComponent } from './delete-user-modal.component';

describe('DeleteUserModalComponent', () => {
  let component: DeleteUserModalComponent;
  let fixture: ComponentFixture<DeleteUserModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteUserModalComponent]
    });
    fixture = TestBed.createComponent(DeleteUserModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
