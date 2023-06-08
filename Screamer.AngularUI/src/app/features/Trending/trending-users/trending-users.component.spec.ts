import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrendingUsersComponent } from './trending-users.component';

describe('TrendingUsersComponent', () => {
  let component: TrendingUsersComponent;
  let fixture: ComponentFixture<TrendingUsersComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TrendingUsersComponent]
    });
    fixture = TestBed.createComponent(TrendingUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
