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
          this.form?.patchValue({
            firstName: user.firstName,
            lastName: user.lastName,
            bio: user.bio,
            website: user.website,
            phone: user.phone,
            birthday: user.birthday,
            gender: user.gender,
            userName: user.userName,
            Facebook: user.social.facebook,
            Twitter: user.social.twitter,
            Instagram: user.social.instagram,
            Youtube: user.social.youtube,
            Twitch: user.social.twitch,
            Tiktok: user.social.tiktok,
            Snapchat: user.social.snapchat,
            Pinterest: user.social.pinterest,
            Reddit: user.social.reddit,
            Linkedin: user.social.linkedin,
            Github: user.social.github,
            Discord: user.social.discord,
            Whatsapp: user.social.whatsapp,
            Telegram: user.social.telegram,
            Skype: user.social.skype,
            Viber: user.social.viber,
            Signal: user.social.signal,
            Slack: user.social.slack,
            Wechat: user.social.wechat,
            Onlyfans: user.social.onlyfans,
            Patreon: user.social.patreon,
            Medium: user.social.medium,
            Tumblr: user.social.tumblr,
            street: user.adress.street,
            city: user.adress.city,
            state: user.adress.state,
            country: user.adress.country,
            postalCode: user.adress.postalCode,

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
        },
      });
  }
}
