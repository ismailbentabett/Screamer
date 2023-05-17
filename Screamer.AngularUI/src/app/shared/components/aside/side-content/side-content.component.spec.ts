import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SideContentComponent } from './side-content.component';

describe('SideContentComponent', () => {
  let component: SideContentComponent;
  let fixture: ComponentFixture<SideContentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SideContentComponent]
    });
    fixture = TestBed.createComponent(SideContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
