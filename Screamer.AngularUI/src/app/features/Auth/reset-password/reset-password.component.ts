import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { ValidationService } from 'src/app/core/services/validation.service';
import { environment } from 'src/environments/environment';

@Component({
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss'],
})
export class ResetPasswordComponent {
  invalidLogin?: boolean;

  url = environment.baseWebApiUrl + '/api/Auth/';
  form: FormGroup;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private authService: AuthenticationService,
    private validationService: ValidationService,
    private route: ActivatedRoute
  ) {
    this.form = this.fb.group(
      {
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(6),
            this.validationService.specialCharactersValidator,
            this.validationService.noWhitespace,
            this.validationService.Numbers,
          ],
        ],
        confirmPassword: [
          '',
          [
            Validators.required,
            Validators.minLength(6),
            this.validationService.specialCharactersValidator,
            this.validationService.noWhitespace,
            this.validationService.Numbers,
          ],
        ],
      },
      { validator: this.passwordMatchValidator }
    );
  }
  passwordMatchValidator(formGroup: FormGroup) {
    const password = formGroup.get('password')!.value;
    const confirmPassword = formGroup.get('confirmPassword')!.value;

    if (password !== confirmPassword) {
      formGroup.get('confirmPassword')!.setErrors({ mismatch: true });
    } else {
      formGroup.get('confirmPassword')!.setErrors(null);
    }
  }

  public resetPassword = () => {
    if (!this.form.valid) return;
    this.route.queryParams.subscribe((params) => {
      const email = params['email'];
      const code = params['code'];
      console.log({
        email: email,
        code: code,
        password: this.form.value.password,
        confirmPassword: this.form.value.confirmPassword,
      });
      this.authService.resetPassword({
        email: email,
        code: code,
        password: this.form.value.password,
        confirmPassword: this.form.value.confirmPassword,
      });
    });
  };
}
