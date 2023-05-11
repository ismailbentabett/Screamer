import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginAndSignupNavComponent } from './login-and-signup-nav.component';

describe('LoginAndSignupNavComponent', () => {
  let component: LoginAndSignupNavComponent;
  let fixture: ComponentFixture<LoginAndSignupNavComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LoginAndSignupNavComponent]
    });
    fixture = TestBed.createComponent(LoginAndSignupNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
