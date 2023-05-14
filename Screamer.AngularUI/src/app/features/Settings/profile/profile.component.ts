import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { User } from 'src/app/core/models/User';
import { BusyService } from 'src/app/core/services/busy.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent {
  form?: FormGroup;
  user?: User;
  constructor(private fb: FormBuilder, private userService: UserService , private busyService : BusyService) {
    this.form = this.fb.group({
      firstName: [' ', Validators.required],
      lastName: [' ', Validators.required],
      bio: [' ', Validators.required],
      website: [' ', Validators.required],
      phone: [' ', Validators.required],
      birthday: [' ', Validators.required],
      gender: [' ', Validators.required],
      userName : [' ', Validators.required]
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
            userName : user.userName
          });
        },
      });
  }
  ngOnInit(): void {}
  onSubmit() {
    this.busyService.busy();

    this.userService
      .updateUser({
        id: this.user?.id,
        ...this.form?.value,
      })
      .subscribe({
        next: () => {
          this.busyService.idle();
        },
        error: () => {
          this.busyService.idle();
        }

      });
  }
}
