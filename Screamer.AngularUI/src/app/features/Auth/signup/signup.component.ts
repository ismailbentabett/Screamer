import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { ValidationService } from 'src/app/core/services/validation.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent {
  form: FormGroup;
  gapi: any;
  errorMessage: any = null;

  constructor(
    private fb: FormBuilder,
    public authService: AuthenticationService,
    private router: Router,
    private validationService: ValidationService
  ) {
    this.form = this.fb.group({
      firstName: [
        '',
        [
          Validators.required,
          this.validationService.noNumbers,
          this.validationService.nospecialCharactersValidator,
          this.validationService.noWhitespace,
        ],
      ],
      lastName: [
        '',
        [
          Validators.required,
          this.validationService.noNumbers,
          this.validationService.nospecialCharactersValidator,
          this.validationService.noWhitespace,
        ],
      ],
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
      userName: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          this.validationService.noWhitespace,
        ],
      ],
    });
  }

  onSubmit() {
    if (!this.form.valid) return;
    this.authService
      .register(this.form.value)

      .subscribe(
        () => {
          this.router.navigate(['/auth/login']);
        },
        (error) => {
          if (error.status === 400) {
            // Handle validation errors
            const validationErrors = error.error.errors;
            if (validationErrors) {
              // Display validation errors to the user
              for (const key in validationErrors) {
                if (validationErrors.hasOwnProperty(key)) {
                  this.errorMessage += `${key}: ${validationErrors[key].join(
                    ', '
                  )}\n`;

                  console.log(this.errorMessage);
                }
              }
              console.log(this.errorMessage);
            }
          } else if (error) {
            if (error.error && error.error.includes('•')) {
              const startIdx = error.error.indexOf('•');
              const endIdx = error.error.indexOf('\n', startIdx + 1);
              error.error.substring(startIdx + 1, endIdx);
              this.errorMessage = error.error.substring(startIdx + 1, endIdx);

              console.log(error.error.substring(startIdx + 1, endIdx));
            } else {
              this.errorMessage = 'Registration failed. Please try again.';
              console.log('Registration failed. Please try again.');
            }
          }
        }
      );
  }
}
