import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  form?: FormGroup;
  constructor(private fb: FormBuilder, private userService: UserService) {
    this.form = this.fb.group({
      firstName: [userService.user?.FirstName ?? ' ', Validators.required],
      lastName: [userService.user?.LastName ?? ' ', Validators.required],
      bio: [userService.user?.Bio ?? ' ', Validators.required],
      website: [userService.user?.Website ?? ' ', Validators.required],
      phone: [userService.user?.Phone ?? ' ', Validators.required],
      birthday: [userService.user?.Birthday ?? ' ', Validators.required],
      gender: [userService.user?.Gender ?? ' ', Validators.required],
    });
  }

  onSubmit() {
    this.userService.updateUser(this.form?.value).subscribe(
      () => {
        console.log('Profile updated');
      },
      (error) => console.error('Profile update failed', error)
    );
  }
}
