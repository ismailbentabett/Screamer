import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CoverUploadComponent } from './cover-upload.component';

describe('CoverUploadComponent', () => {
  let component: CoverUploadComponent;
  let fixture: ComponentFixture<CoverUploadComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CoverUploadComponent]
    });
    fixture = TestBed.createComponent(CoverUploadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
