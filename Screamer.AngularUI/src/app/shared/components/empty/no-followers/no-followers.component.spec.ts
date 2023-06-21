import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoFollowersComponent } from './no-followers.component';

describe('NoFollowersComponent', () => {
  let component: NoFollowersComponent;
  let fixture: ComponentFixture<NoFollowersComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NoFollowersComponent]
    });
    fixture = TestBed.createComponent(NoFollowersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
