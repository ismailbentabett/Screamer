import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FollowModalComponent } from './follow-modal.component';

describe('FollowModalComponent', () => {
  let component: FollowModalComponent;
  let fixture: ComponentFixture<FollowModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FollowModalComponent]
    });
    fixture = TestBed.createComponent(FollowModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
