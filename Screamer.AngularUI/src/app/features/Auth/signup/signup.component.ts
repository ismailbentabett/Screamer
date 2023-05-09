import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent {
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthenticationService
  ) {
    this.form = this.fb.group({
      firstName: ['', Validators.required],
      userName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(20),
        ],
      ],
    });
  }

  onSubmit() {
    const { firstName, lastName, email, password , userName } = this.form.value;
    console.log(
      {
        firstName,
        lastName,
        email,
        password
      }
    )
    this.authService.register(firstName, lastName, email, password , userName).subscribe(

      () =>{
            console.log(
            {
              firstName,
              lastName,
              email,
              password,
              userName
            }
          )
      },
      (error) => console.error('Registration failed', error)
    );
  }
}
