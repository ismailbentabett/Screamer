import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { UserService } from 'src/app/core/services/user.service';
import { ValidationService } from 'src/app/core/services/validation.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
})
export class AuthComponent {
  currentUser: any = null;
  form: FormGroup<any>;
  /**
   *
   */
  constructor(
    private userService: UserService,
    private authService: AuthenticationService,
    private router: Router,
    private fb: FormBuilder,
    private validationService: ValidationService,
    private route: ActivatedRoute
  ) {
    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.currentUser = user;
        },
      });

    this.form = this.fb.group(
      {
        oldPassword: [
          '',
          [
            Validators.required,
            Validators.minLength(6),
            this.validationService.specialCharactersValidator,
            this.validationService.noWhitespace,
            this.validationService.Numbers,
          ],
        ],
        newPassword: [
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
    const newPassword = formGroup.get('newPassword')!.value;
    const confirmPassword = formGroup.get('confirmPassword')!.value;
    const oldPassword = formGroup.get('oldPassword')!.value;

    if (newPassword !== confirmPassword) {
      formGroup.get('confirmPassword')!.setErrors({ mismatch: true });
    } else {
      formGroup.get('confirmPassword')!.setErrors(null);
    }

    if (newPassword === oldPassword) {
      formGroup.get('newPassword')!.setErrors({ sameAsOld: true });
    } else {
      formGroup.get('newPassword')!.setErrors(null);
    }
  }

  changePassword() {
    if (!this.form.valid) return;
    console.log({
      email: this.currentUser.email,
      oldPassword: this.form.get('oldPassword')!.value,
      newPassword: this.form.get('newPassword')!.value,
      confirmPassword: this.form.get('confirmPassword')!.value,
    });
    this.authService.changePassword({
      email: this.currentUser.email,
      oldPassword: this.form.get('oldPassword')!.value,
      newPassword: this.form.get('newPassword')!.value,
      confirmPassword: this.form.get('confirmPassword')!.value,
    });
  }
}
