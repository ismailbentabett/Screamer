import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { User } from 'src/app/core/models/User';
import { UserUpdateInput } from 'src/app/core/models/UserUpdateInput';
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
  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private busyService: BusyService
  ) {
    this.form = this.fb.group({
      firstName: [' ', Validators.required],
      lastName: [' ', Validators.required],
      bio: [' ', Validators.required],
      website: [' ', Validators.required],
      phone: [' ', Validators.required],
      birthday: [' ', Validators.required],
      gender: [' ', Validators.required],
      userName: [' ', Validators.required],
      Facebook: [' ', Validators.required],
      Twitter: [' ', Validators.required],
      Instagram: [' ', Validators.required],
      Youtube: [' ', Validators.required],
      Twitch: [' ', Validators.required],
      Tiktok: [' ', Validators.required],
      Snapchat: [' ', Validators.required],
      Pinterest: [' ', Validators.required],
      Reddit: [' ', Validators.required],
      Linkedin: [' ', Validators.required],
      Github: [' ', Validators.required],
      Discord: [' ', Validators.required],
      Whatsapp: [' ', Validators.required],
      Telegram: [' ', Validators.required],
      Skype: [' ', Validators.required],
      Viber: [' ', Validators.required],
      Signal: [' ', Validators.required],
      Slack: [' ', Validators.required],
      Wechat: [' ', Validators.required],
      Onlyfans: [' ', Validators.required],
      Patreon: [' ', Validators.required],
      Medium: [' ', Validators.required],
      Tumblr: [' ', Validators.required],
      street: [' ', Validators.required],
      city: [' ', Validators.required],
      state: [' ', Validators.required],
      country: [' ', Validators.required],
      postalCode: [' ', Validators.required],
    });

    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.user = user;
          this.form?.patchValue({ ...user });
        },
      });
  }
  ngOnInit(): void {}
  onSubmit() {
    this.busyService.busy();
    const { values }: { values: UserUpdateInput } = this.form?.value;
    values.id = this.user!.id;
    values.createdAt = this.user?.createdAt as Date;
    values.updatedAt = this.user?.updatedAt as Date;
    this.userService
      .updateUser({
        ...values,
      })
      .subscribe({
        next: () => {
          this.busyService.idle();
        },
        error: () => {
          this.busyService.idle();
        },
      });
  }
}
