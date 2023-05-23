import { Component, Input } from '@angular/core';
import { map, toPairs, values } from 'lodash';
import { Social } from 'src/app/core/models/Social';
import { User } from 'src/app/core/models/User';

@Component({
  selector: 'app-socials-list',
  templateUrl: './socials-list.component.html',
  styleUrls: ['./socials-list.component.scss'],
})
export class SocialsListComponent {
  @Input() user!: User;
  socials: Social | null = null;
  socialsArray: any[] | null = null;
  constructor() {}
  generateSocialLink(platform: string, username: string) {
    switch (platform) {
      case 'facebook':
        return `https://facebook.com/${username}`;
      case 'twitter':
        return `https://twitter.com/${username}`;
      case 'instagram':
        return `https://instagram.com/${username}`;
      case 'youtube':
        return `https://youtube.com/user/${username}`;
      case 'twitch':
        return `https://twitch.tv/${username}`;
      case 'tiktok':
        return `https://www.tiktok.com/@${username}`;
      case 'snapchat':
        return `https://www.snapchat.com/add/${username}`;
      case 'pinterest':
        return `https://www.pinterest.com/${username}`;
      case 'reddit':
        return `https://www.reddit.com/user/${username}`;
      case 'linkedin':
        return `https://www.linkedin.com/in/${username}`;
      case 'github':
        return `https://github.com/${username}`;
      case 'discord':
        return `https://discord.com/users/${username}`;
      case 'whatsapp':
        return `https://wa.me/${username}`;
      case 'telegram':
        return `https://telegram.me/${username}`;
      case 'skype':
        return `https://join.skype.com/invite/${username}`;
      case 'viber':
        return `viber://add?number=${username}`;
      case 'signal':
        return `https://signal.me/#/${username}`;
      case 'slack':
        return `https://${username}.slack.com`;
      case 'wechat':
        return `https://u.wechat.com/${username}`;
      case 'onlyfans':
        return `https://onlyfans.com/${username}`;
      case 'patreon':
        return `https://www.patreon.com/${username}`;
      case 'medium':
        return `https://medium.com/@${username}`;
      case 'tumblr':
        return `https://${username}.tumblr.com`;
      default:
        return 'Invalid platform.';
    }
  }

  //replace tiktok patreo onlyfans and viber keys with a generic font awsome icon
  //and replace the value with the link to the social media

  iconify(social: string) {
    if (
      social === 'tiktok' ||
      social == 'onlyfans' ||
      social == 'patreon' ||
      social == 'viber'
    ) {
      return 'fa fa-globe';
    } else {
      return `fa fa-${social}`;
    }
  }

  ngOnInit(): void {
    if (this.user.socials) {
      this.socials = this.user.socials;
      //turn socials object to array
      this.socialsArray = map(toPairs(this.socials), ([key, value]) => ({
        key: this.iconify(key),
        value: value == ' ' ? null : this.generateSocialLink(key, value),
      })).filter((social) => social.value != null);
    }
  }
}
