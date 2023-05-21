import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, RouterLinkActive } from '@angular/router';
import { MessageService } from 'src/app/core/services/message.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent {
  form: FormGroup;
  emojiMartVisible: any;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private messagesService: MessageService
  ) {
    this.form = this.fb.group({
      message: ['', Validators.required],
    });
  }
ngOnInit() : void  {
this.getChatRoomById()
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

  getChatRoomById() {
    this.route.params.subscribe((params: Params) => {
      const prodId = params['roomId'];
      this.messagesService.getChatRoomById(prodId).subscribe({
        next: (data) => {
          console.log(data);
        },
      });
    });
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
