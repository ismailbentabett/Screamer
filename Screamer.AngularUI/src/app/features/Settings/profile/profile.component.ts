import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent {
  form?: FormGroup;
  user: any;
  constructor(private fb: FormBuilder, private userService: UserService) {
    this.form = this.fb.group({
      firstName: [' ', Validators.required],
      lastName: [' ', Validators.required],
      bio: [' ', Validators.required],
      website: [' ', Validators.required],
      phone: [' ', Validators.required],
      birthday: [' ', Validators.required],
      gender: [' ', Validators.required],
    });

    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.user = user;
          this.form?.patchValue({
            firstName: user.firstName,
            lastName: user.lastName,
            bio: user.bio,
            website: user.website,
            phone: user.phone,
            birthday: user.birthday,
            gender: user.gender,
          });
        },
      });
  }
  ngOnInit(): void {}
  onSubmit() {
    this.userService
      .updateUser({
        id: this.user.id,
        ...this.form?.value,
      })
      .subscribe(
        () => {
          console.log('Profile updated');
        },
        (error) => console.error('Profile update failed', error)
      );
  }
}
