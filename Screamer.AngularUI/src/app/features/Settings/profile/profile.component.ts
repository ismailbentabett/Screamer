import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs/operators';
import { User } from 'src/app/core/models/User';
import { UserUpdateInput } from 'src/app/core/models/UserUpdateInput';
import { BusyService } from 'src/app/core/services/busy.service';
import { CountryService } from 'src/app/core/services/country.service';
import { UserService } from 'src/app/core/services/user.service';
import { ValidationService } from 'src/app/core/services/validation.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  form!: FormGroup;
  user!: User;
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
    private validationService: ValidationService,
    public countryService: CountryService
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      firstName: [
        '',
        [
          this.validationService.noNumbers,
          this.validationService.nospecialCharactersValidator,
          this.validationService.noWhitespace,
          Validators.required,
        ],
      ],
      lastName: [
        '',
        [
          this.validationService.noNumbers,
          this.validationService.nospecialCharactersValidator,
          this.validationService.noWhitespace,
          Validators.required,
        ],
      ],
      bio: ['', [Validators.minLength(1), Validators.maxLength(500)]],
      website: ['', [Validators.maxLength(500)]],
      phone: [''],
      birthday: [''],
      gender: [''],
      userName: [
        '',
        [
          Validators.minLength(3),
          this.validationService.noWhitespace,
          Validators.required,
        ],
      ],
      adress: this.fb.group({
        street: [''],
        city: [''],
        state: [''],
        country: [''],
        postalCode: [''],
      }),
      socials: this.fb.group({
        facebook: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        twitter: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        instagram: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        youtube: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        twitch: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        tiktok: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        snapchat: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        pinterest: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        reddit: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        linkedin: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        github: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        discord: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        whatsapp: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        telegram: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        skype: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        viber: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        signal: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        slack: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        wechat: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        onlyfans: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        patreon: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        medium: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
        tumblr: [
          '',
          [Validators.maxLength(500), this.validationService.noWhitespace],
        ],
      }),
    });

    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe((user: User) => {
        this.user = user;
        this.form.patchValue({ ...user });
      });


  }

  onSubmit() {
    if (!this.form.valid) return;

    ;
    const values: UserUpdateInput = this.form.value;
    this.userService.updateUser(values, this.user.id).subscribe(
      () => {
        ;
      },
      (error) => {
        ;
      }
    );
  }
}
