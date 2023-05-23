import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SocialsListComponent } from './socials-list.component';

describe('SocialsListComponent', () => {
  let component: SocialsListComponent;
  let fixture: ComponentFixture<SocialsListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SocialsListComponent]
    });
    fixture = TestBed.createComponent(SocialsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
