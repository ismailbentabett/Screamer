import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScreamingComponent } from './screaming.component';

describe('ScreamingComponent', () => {
  let component: ScreamingComponent;
  let fixture: ComponentFixture<ScreamingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ScreamingComponent]
    });
    fixture = TestBed.createComponent(ScreamingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
