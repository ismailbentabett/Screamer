import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FacebookSocialAuthButtonComponent } from './facebook-social-auth-button.component';

describe('FacebookSocialAuthButtonComponent', () => {
  let component: FacebookSocialAuthButtonComponent;
  let fixture: ComponentFixture<FacebookSocialAuthButtonComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FacebookSocialAuthButtonComponent]
    });
    fixture = TestBed.createComponent(FacebookSocialAuthButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
