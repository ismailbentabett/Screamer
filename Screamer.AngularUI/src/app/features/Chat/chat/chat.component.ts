import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  ActivatedRoute,
  NavigationEnd,
  Params,
  Router,
  RouterLinkActive,
} from '@angular/router';
import { take } from 'rxjs';
import { MessageParams } from 'src/app/core/models/MessageParams';
import { Pagination } from 'src/app/core/models/Pagination';
import { User } from 'src/app/core/models/User';
import { BusyService } from 'src/app/core/services/busy.service';
import { MessageService } from 'src/app/core/services/message.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent {
  form: FormGroup;
  emojiMartVisible: any;
  room: any;

  messages: any[] | undefined;
  pageNumber = 1;
  pageSize = 5;
  pagination: Pagination | undefined;
  messageParams: MessageParams | undefined;
  next: string | undefined;
  userId?: string;
  user!: User;
  currentUserId?: string;
  currentUser!: User;
  someSubscription: any;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private messagesService: MessageService,
    private userService: UserService,
    private router: Router,
    private busyService: BusyService

  ) {
    this.form = this.fb.group({
      message: ['', Validators.required],
    });
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
     let roomId= params.get('roomId');
    this.getChatRoomById(roomId);
    })
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

  getChatRoomById(roomId : any) {
    this.busyService.busy();
      this.messagesService.getChatRoomById(roomId as any).subscribe({
        next: (data) => {
          this.room = data;

          this.userService
            .getCurrentUserData()
            .pipe(take(1))
            .subscribe({
              next: (user: any) => {
                this.currentUser = user;
                this.currentUserId = user.id;
                this.userId = this.room.chatRoomUsers.filter(
                  (x: any) => x.userId != this.currentUserId
                )[0].userId;

                this.messageParams = this.messagesService.getMessageParams(
                  this.userId as string,
                  this.pageSize,
                  this.pageNumber,
                  this.currentUserId as string
                );

                console.log('this.messageParams', this.messageParams);
                this.userService.getUserById(this.userId as string).subscribe({
                  next: (user: any) => {
                    this.user = user;
                    this.loadMessages();
                    this.busyService.idle();
                  },
                });
              },
            });
        },
      });

  }

  loadMessages() {
    this.busyService.busy()
    if (this.messageParams) {
      this.messagesService.setMessageParams(this.messageParams);
      this.messagesService.getMessageThread(this.messageParams).subscribe({
        next: (response) => {
          if (response.result && response.pagination) {
            this.messages = response.result;
            this.pagination = response.pagination;
                this.busyService.idle()
            console.log(this.messages);
          }
        },
      });
    }
  }

  loadMoreMessages() {
    if (this.messageParams && this.pagination) {
      this.messageParams.pageNumber = this.pagination.currentPage + 1;
      this.messagesService.setMessageParams(this.messageParams);
      this.messagesService.getMessageThread(this.messageParams).subscribe({
        next: (response) => {
          if (response.result && response.pagination) {
            this.messages?.push(...response.result);
            this.pagination = response.pagination;
          }
        },
      });
    }
  }

  onSubmit() {
    /*    this.messagesService.sendMessage(
          recipientId,
          this.form.get('message')?.value,
          this.userId as string
        )
        */
  }

   getClassNames(message : any, currentUser : any) {
    if (message.senderId !== currentUser.id) {
      return 'flex flex-row items-center';
    } else {
      return 'flex items-center justify-start flex-row-reverse';
    }



  }
}
