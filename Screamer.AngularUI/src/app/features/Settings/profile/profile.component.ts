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
  socials = [
    'facebook',
    'twitter',
    'instagram',
    'youtube',
    'twitch',
    'tiktok',
    'snapchat',
    'pinterest',
    'reddit',
    'linkedin',
    'github',
    'whatsapp',
    'telegram',
    'skype',
    'viber',
    'signal',
    'slack',
    'wechat',
    'onlyfans',
    'patreon',
    'medium',
    'tumblr',
  ];
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

      adress: this.fb.group({
        street: [' ', Validators.required],
        city: [' ', Validators.required],
        state: [' ', Validators.required],
        country: [' ', Validators.required],
        postalCode: [' ', Validators.required],
      }),
      socials: this.fb.group({
        facebook: [' ', Validators.required],
        twitter: [' ', Validators.required],
        instagram: [' ', Validators.required],
        youtube: [' ', Validators.required],
        twitch: [' ', Validators.required],
        tiktok: [' ', Validators.required],
        snapchat: [' ', Validators.required],
        pinterest: [' ', Validators.required],
        reddit: [' ', Validators.required],
        linkedin: [' ', Validators.required],
        github: [' ', Validators.required],
        discord: [' ', Validators.required],

        whatsapp: [' ', Validators.required],
        telegram: [' ', Validators.required],
        skype: [' ', Validators.required],
        viber: [' ', Validators.required],
        signal: [' ', Validators.required],
        slack: [' ', Validators.required],

        wechat: [' ', Validators.required],
        onlyfans: [' ', Validators.required],
        patreon: [' ', Validators.required],
        medium: [' ', Validators.required],
        tumblr: [' ', Validators.required],
      }),
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
  ngOnChanges(): void {
    console.log(this.form?.value);
  }
  onSubmit() {
    this.busyService.busy();
    const values: UserUpdateInput = this.form?.value;
    console.log(values);
    this.userService.updateUser(values, this.user?.id as number).subscribe({
      next: () => {
        this.busyService.idle();
      },
      error: (err) => {
        console.log(err);
        this.busyService.idle();
      },
    });
  }
}
