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

  constructor(
    private fb: FormBuilder,
    private authService: AuthenticationService,
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
          Validators.maxLength(20),
          this.validationService.specialCharactersValidator,
          this.validationService.noWhitespace,
          this.validationService.Numbers,
        ],
      ],
      userName: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          this.validationService.noWhitespace,
        ],
      ],
    });
  }

  ngOnInit(): void {
    this.form.valueChanges.subscribe((value) => console.log(this.form));
  }

  onSubmit() {
    if (!this.form.valid) return;
    this.authService.register(this.form.value).subscribe(
      () => {
        this.router.navigate(['/auth/login']);
      },
      (error) => console.error('Registration failed', error)
    );
  }
}
