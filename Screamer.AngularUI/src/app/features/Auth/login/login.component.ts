import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { ValidationService } from 'src/app/core/services/validation.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  invalidLogin?: boolean;

  url = environment.baseWebApiUrl + '/api/Auth/';
  form: FormGroup;
  errorMessage: any = null;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private authService: AuthenticationService,
    private validationService: ValidationService
  ) {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          this.validationService.specialCharactersValidator,
          this.validationService.noWhitespace,
          this.validationService.Numbers,
          this.validationService.uppercase,
        ],
      ],
    });
  }

  public login = () => {
    if (!this.form.valid) return;

    this.authService.login(this.form.value).subscribe(
      () => {
        this.router.navigate(['/v/feed']);
      },
      (error) => {
        this.errorMessage = this.extractErrorMessage(error);
      }
    );
  };
  private extractErrorMessage(error: any): string {
    if (error && error.error && error.error.ExceptionMessage) {
      const errorMessage = error.error.ExceptionMessage;
      const startIndex = errorMessage.indexOf(':') + 1;
      const endIndex = errorMessage.indexOf('\n');
      return errorMessage.substring(startIndex, endIndex).trim();
    }
    return 'Credentials are not valid';
  }
}
