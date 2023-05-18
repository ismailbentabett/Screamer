import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FollowCardComponent } from './follow-card.component';

describe('FollowCardComponent', () => {
  let component: FollowCardComponent;
  let fixture: ComponentFixture<FollowCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FollowCardComponent]
    });
    fixture = TestBed.createComponent(FollowCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
