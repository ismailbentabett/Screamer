import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Emoji } from '@ctrl/ngx-emoji-mart/ngx-emoji';
import { MessageService } from 'src/app/core/services/message.service';

@Component({
  selector: 'app-chat-room',
  templateUrl: './chat-room.component.html',
  styleUrls: ['./chat-room.component.scss'],
})
export class ChatRoomComponent {
  emojiMartVisible: boolean = false;
  form: FormGroup;

  constructor(private fb: FormBuilder , private messagesService : MessageService) {
    this.form = this.fb.group({
      message: ['', Validators.required],
    });
  }
  toggleEmojiMart(): void {
    this.emojiMartVisible = !this.emojiMartVisible;
    console.log(this.emojiMartVisible);
  }
  addEmoji($event: { emoji: { native: any; }; }) {
    let data = this.form.get('message');
console.log(data)
    data!.patchValue(data!.value + $event.emoji.native);
  }
  onSubmit()
  {
    console.log(this.form.value);
  }
  getUserChatRooms(

  )
}
