import { Component, Input } from '@angular/core';
import { avatarEnum } from 'src/app/core/enums/avatar.enum';
import { User } from 'src/app/core/models/User';
import { createAvatar } from '@dicebear/core';
import { bigEarsNeutral } from '@dicebear/collection';

@Component({
  selector: 'app-avatar',
  templateUrl: './avatar.component.html',
  styleUrls: ['./avatar.component.scss'],
})
export class AvatarComponent {
  @Input() url?: string;
  @Input() user?: User;
  @Input() avatarStyle?: string;


  avatar: any;

  constructor() {



  }

  ngOnInit(): void {
    console.log(this.user)
    const url = createAvatar(bigEarsNeutral, {
      seed: `
      ${this.user?.firstName} ${this.user?.lastName}
      `,

      // ... other options
    }).toString();

    this.avatar = 'data:image/svg+xml;utf8,' + encodeURIComponent(url);  }

}
