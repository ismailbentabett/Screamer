import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoogleSocialAuthButtonComponent } from './google-social-auth-button.component';

describe('GoogleSocialAuthButtonComponent', () => {
  let component: GoogleSocialAuthButtonComponent;
  let fixture: ComponentFixture<GoogleSocialAuthButtonComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GoogleSocialAuthButtonComponent]
    });
    fixture = TestBed.createComponent(GoogleSocialAuthButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
