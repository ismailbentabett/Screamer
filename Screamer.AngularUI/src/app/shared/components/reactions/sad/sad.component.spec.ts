import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SadComponent } from './sad.component';

describe('SadComponent', () => {
  let component: SadComponent;
  let fixture: ComponentFixture<SadComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SadComponent]
    });
    fixture = TestBed.createComponent(SadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
