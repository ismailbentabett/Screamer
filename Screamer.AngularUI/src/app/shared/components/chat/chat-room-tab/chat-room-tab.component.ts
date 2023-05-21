import { Component, Input } from '@angular/core';
import { User } from 'src/app/core/models/User';
import { UserService } from 'src/app/core/services/user.service';
//import lodash
import {head} from 'lodash';
import { Message } from 'src/app/core/models/Message';
@Component({
  selector: 'app-chat-room-tab',
  templateUrl: './chat-room-tab.component.html',
  styleUrls: ['./chat-room-tab.component.scss']
})
export class ChatRoomTabComponent {
  @Input() chatRoom!: any ;
  @Input() userId!: any ;
   user!: User;
   latestMessage! : Message
  constructor(private userService: UserService) {}
  ngOnInit(): void {

    let  theOtherUser = this.chatRoom.chatRoomUsers.filter((x : any)=>x.userId!=this.userId)
    this.latestMessage  =
    this.chatRoom.latestMessage
   if(theOtherUser){
   let headUser =
   head(theOtherUser) as any
    this.userService.getUserById( headUser.userId).subscribe({
      next: (data) => {
        this.user = data;
      },
    });
   }

  }
}
