import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  invalidLogin?: boolean;

  url = environment.baseWebApiUrl + '/api/Auth/';
  form: FormGroup;

  constructor(
    private router: Router,
    private http: HttpClient,
    private fb: FormBuilder,
    private authService: AuthenticationService
  ) {
    this.form = this.fb.group({
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

  public login = () => {
    const { email, password } = this.form.value;

    const credentials = {
      email,
      password,
    };
    this.http
      .post(this.url + 'login', credentials, {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
      })
      .subscribe(
        (response) => {
          console.log(response);
          const token = (<any>response).token;
          localStorage.setItem('jwt', token);
          this.invalidLogin = false;
          this.router.navigate(['/']);
        },
        (error) => console.error('Login failed', error)

      );
  };
}
