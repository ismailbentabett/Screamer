import { Component } from '@angular/core';

@Component({
  selector: 'app-chat-room',
  templateUrl: './chat-room.component.html',
  styleUrls: ['./chat-room.component.scss']
})
export class ChatRoomComponent {
  emojiMartVisible: boolean = false;

  toggleEmojiMart(): void {
    this.emojiMartVisible = !this.emojiMartVisible;
    console.log(
      this.emojiMartVisible
    )
  }
}
