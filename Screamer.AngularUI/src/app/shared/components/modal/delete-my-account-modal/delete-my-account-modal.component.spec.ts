import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteMyAccountModalComponent } from './delete-my-account-modal.component';

describe('DeleteMyAccountModalComponent', () => {
  let component: DeleteMyAccountModalComponent;
  let fixture: ComponentFixture<DeleteMyAccountModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteMyAccountModalComponent]
    });
    fixture = TestBed.createComponent(DeleteMyAccountModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
