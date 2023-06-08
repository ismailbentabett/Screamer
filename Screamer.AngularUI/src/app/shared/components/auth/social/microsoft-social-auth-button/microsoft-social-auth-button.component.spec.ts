import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MicrosoftSocialAuthButtonComponent } from './microsoft-social-auth-button.component';

describe('MicrosoftSocialAuthButtonComponent', () => {
  let component: MicrosoftSocialAuthButtonComponent;
  let fixture: ComponentFixture<MicrosoftSocialAuthButtonComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MicrosoftSocialAuthButtonComponent]
    });
    fixture = TestBed.createComponent(MicrosoftSocialAuthButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
