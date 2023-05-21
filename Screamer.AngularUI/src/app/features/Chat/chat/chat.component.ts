import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent {
  form: FormGroup;
  emojiMartVisible: any;

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      message: ['', Validators.required],
    });
  }

  toggleEmojiMart(): void {
    this.emojiMartVisible = !this.emojiMartVisible;
    console.log(this.emojiMartVisible);
  }
  addEmoji($event: { emoji: { native: any } }) {
    let data = this.form.get('message');
    console.log(data);
    data!.patchValue(data!.value + $event.emoji.native);
  }

  onSubmit() {
    /*    this.messagesService.sendMessage(
          recipientId,
          this.form.get('message')?.value,
          this.userId as string
        )
        */
      }
}
