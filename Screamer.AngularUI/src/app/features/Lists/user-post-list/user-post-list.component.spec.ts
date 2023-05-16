import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPostListComponent } from './user-post-list.component';

describe('UserPostListComponent', () => {
  let component: UserPostListComponent;
  let fixture: ComponentFixture<UserPostListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserPostListComponent]
    });
    fixture = TestBed.createComponent(UserPostListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
