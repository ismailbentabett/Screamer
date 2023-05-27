import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExcitedComponent } from './excited.component';

describe('ExcitedComponent', () => {
  let component: ExcitedComponent;
  let fixture: ComponentFixture<ExcitedComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExcitedComponent]
    });
    fixture = TestBed.createComponent(ExcitedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
