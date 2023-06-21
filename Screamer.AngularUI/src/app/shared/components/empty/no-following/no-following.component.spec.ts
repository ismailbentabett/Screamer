import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoFollowingComponent } from './no-following.component';

describe('NoFollowingComponent', () => {
  let component: NoFollowingComponent;
  let fixture: ComponentFixture<NoFollowingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NoFollowingComponent]
    });
    fixture = TestBed.createComponent(NoFollowingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
