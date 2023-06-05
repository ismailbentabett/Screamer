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
        Validators.required,
      ],
      lastName: [
        ' ',
        this.validationService.noNumbers,
        this.validationService.nospecialCharactersValidator,
        this.validationService.noWhitespace,
        Validators.required,
      ],
      bio: [' ', Validators.maxLength(500)],
      website: [' ', Validators.maxLength(500), this.validationService.website],
      phone: [' ', this.validationService.phone],
      birthday: [' '],
      gender: [' '],
      userName: [
        ' ',
        ,
        Validators.minLength(3),
        this.validationService.noWhitespace,
        Validators.required,
      ],

      adress: this.fb.group({
        street: [' ', Validators.maxLength(500), this.validationService.street],
        city: [' ', Validators.maxLength(500), this.validationService.city],
        state: [' ', Validators.maxLength(500), this.validationService.state],
        country: [' '],
        postalCode: [
          ' ',
          Validators.maxLength(500),
          this.validationService.postalCode,
        ],
      }),
      socials: this.fb.group({
        facebook: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        twitter: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        instagram: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        youtube: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        twitch: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        tiktok: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        snapchat: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        pinterest: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        reddit: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        linkedin: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        github: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        discord: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],

        whatsapp: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        telegram: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        skype: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        viber: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        signal: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        slack: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],

        wechat: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        onlyfans: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        patreon: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        medium: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
        tumblr: [
          ' ',
          Validators.maxLength(500),
          this.validationService.socialMediaUsername,
          this.validationService.noWhitespace,
        ],
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
