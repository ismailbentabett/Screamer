import { Component, Input } from '@angular/core';
import { avatarEnum } from 'src/app/core/enums/avatar.enum';
import { User } from 'src/app/core/models/User';

@Component({
  selector: 'app-avatar',
  templateUrl: './avatar.component.html',
  styleUrls: ['./avatar.component.scss']
})
export class AvatarComponent {
@Input() url? : string ;
@Input() user? : User;
@Input() size? : avatarEnum;

  constructor() { }


}
