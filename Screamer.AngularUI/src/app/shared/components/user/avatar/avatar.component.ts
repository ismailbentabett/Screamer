import { Component, Input } from '@angular/core';
import { avatarEnum } from 'src/app/core/enums/avatar.enum';
import { User } from 'src/app/core/models/User';
import { createAvatar } from '@dicebear/core';
import { bigEarsNeutral } from '@dicebear/collection';
import { PresenceService } from 'src/app/core/services/presence.service';
import { HttpBackend, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-avatar',
  templateUrl: './avatar.component.html',
  styleUrls: ['./avatar.component.scss'],
})
export class AvatarComponent {
  @Input() url?: string;
  @Input() user?: any;
  @Input() avatarStyle?: string;

  avatar: any;
  private httpClient: HttpClient;

  constructor(
    public presenceService: PresenceService,
    private handler: HttpBackend
  ) {
    this.httpClient = new HttpClient(handler);
  }

  ngOnInit(): void {
    const url = createAvatar(bigEarsNeutral, {
      seed: `${this.user?.userName}`,

      // ... other options
    }).toString();

    this.avatar = 'data:image/svg+xml;utf8,' + encodeURIComponent(url);
  }

  getAvatar() {
    if (this.user?.avatarUrl) {
      return this.user?.avatarUrl;
    } else {
      return this.avatar;
    }
  }
}
