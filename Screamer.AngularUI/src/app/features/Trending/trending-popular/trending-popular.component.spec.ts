import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrendingPopularComponent } from './trending-popular.component';

describe('TrendingPopularComponent', () => {
  let component: TrendingPopularComponent;
  let fixture: ComponentFixture<TrendingPopularComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TrendingPopularComponent]
    });
    fixture = TestBed.createComponent(TrendingPopularComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
