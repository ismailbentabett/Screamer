import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { User } from 'src/app/core/models/User';
import { MessageService } from 'src/app/core/services/message.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent {
  currentUser!: User;
  @Input() recipientId!: string;
  constructor(
    private messageService: MessageService,
    private userService: UserService,
    private router: Router
  ) {
    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.currentUser = user;
        },
      });
  }

  createRoom() {
    console.log(
      this.currentUser.id.toString() as string,
      ' ',
      this.recipientId
    );
    this.messageService
      .createRoom(this.currentUser.id.toString() as string, this.recipientId)
      .subscribe({
        next: (data) => {
          this.router.navigateByUrl('/v/chat/' + data);
        },
      });
  }
}
