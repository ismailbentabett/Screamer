import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { User } from 'src/app/core/models/User';
import { UserUpdateInput } from 'src/app/core/models/UserUpdateInput';
import { BusyService } from 'src/app/core/services/busy.service';
import { UserService } from 'src/app/core/services/user.service';
import { ValidationService } from 'src/app/core/services/validation.service';

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
    private busyService: BusyService,
    private validationService: ValidationService
  ) {
    this.form = this.fb.group({
      firstName: [
        ' ',
        this.validationService.noNumbers,
        this.validationService.nospecialCharactersValidator,
        this.validationService.noWhitespace,
      ],
      lastName: [
        ' ',
        this.validationService.noNumbers,
        this.validationService.nospecialCharactersValidator,
        this.validationService.noWhitespace,
      ],
      bio: [' ', Validators.maxLength(500)],
      website: [' ', Validators.maxLength(500), this.validationService.website],
      phone: [' ', this.validationService.phone],
      birthday: [' '],
      gender: [' '],
      userName: [
        ' ',
        Validators.required,
        Validators.minLength(3),
        this.validationService.noWhitespace,
      ],

      adress: this.fb.group({
        street: [
          ' ',
          Validators.required,
          Validators.maxLength(500),
          this.validationService.street,
        ],
        city: [
          ' ',
          Validators.required,
          Validators.maxLength(500),
          this.validationService.city,
        ],
        state: [
          ' ',
          Validators.required,
          Validators.maxLength(500),
          this.validationService.state,
        ],
        country: [' ', Validators.required],
        postalCode: [
          ' ',
          Validators.required,
          Validators.maxLength(500),
          this.validationService.postalCode,
        ],
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

  onSubmit() {
    this.busyService.busy();
    const values: UserUpdateInput = this.form?.value;
    this.userService.updateUser(values, this.user?.id as number).subscribe({
      next: () => {
        this.busyService.idle();
      },
      error: (err) => {
        this.busyService.idle();
      },
    });
  }
}
