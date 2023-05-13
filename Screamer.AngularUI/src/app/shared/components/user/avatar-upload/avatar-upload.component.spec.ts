import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvatarUploadComponent } from './avatar-upload.component';

describe('AvatarUploadComponent', () => {
  let component: AvatarUploadComponent;
  let fixture: ComponentFixture<AvatarUploadComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AvatarUploadComponent]
    });
    fixture = TestBed.createComponent(AvatarUploadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
