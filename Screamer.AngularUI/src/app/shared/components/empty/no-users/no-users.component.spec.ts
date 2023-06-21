import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoUsersComponent } from './no-users.component';

describe('NoUsersComponent', () => {
  let component: NoUsersComponent;
  let fixture: ComponentFixture<NoUsersComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NoUsersComponent]
    });
    fixture = TestBed.createComponent(NoUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
