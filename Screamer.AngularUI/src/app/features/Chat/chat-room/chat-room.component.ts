import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Emoji } from '@ctrl/ngx-emoji-mart/ngx-emoji';
import { take } from 'rxjs';
import { ChatRoomParams } from 'src/app/core/models/ChatRoomParams';
import { Pagination } from 'src/app/core/models/Pagination';
import { User } from 'src/app/core/models/User';
import { MessageService } from 'src/app/core/services/message.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-chat-room',
  templateUrl: './chat-room.component.html',
  styleUrls: ['./chat-room.component.scss'],
})
export class ChatRoomComponent {
  emojiMartVisible: boolean = false;
  form: FormGroup;
  chatRooms: any[] | undefined;
  pageNumber = 1;
  pageSize = 5;
  pagination: Pagination | undefined;
  chatRoomParams: ChatRoomParams | undefined;
  next: string | undefined;
  userId?: string;
  user!: User;

  constructor(
    private fb: FormBuilder,
    private messagesService: MessageService,
    private userService: UserService
  ) {
    this.form = this.fb.group({
      message: ['', Validators.required],
    });


  }


  ngOnInit(): void {


    this.userService
    .getCurrentUserData()
    .pipe(take(1))
    .subscribe({
      next: (user: any) => {
        this.userId =
        user.id;
        this.chatRoomParams = this.messagesService.getChatRoomParams(
          user.id,
          this.pageSize,
          this.pageNumber
        );
        this.loadRooms();      },
    });

  }
  loadRooms() {
    if (this.chatRoomParams) {
      console.log(
        'this.chatRoomParams',
        this.chatRoomParams,
      )
      this.messagesService.setChatRoomParams(this.chatRoomParams);
      this.messagesService.getUserChatRooms(this.chatRoomParams).subscribe({
        next: (response) => {
          console.log(response)
          if (response.result && response.pagination) {
            this.chatRooms = response.result;
            this.pagination = response.pagination;
          }
        },
      });
    }
  }

  loadMoreRooms() {
    if (this.chatRoomParams && this.pagination) {
      this.chatRoomParams.pageNumber = this.pagination.currentPage + 1;
      this.messagesService.setChatRoomParams(this.chatRoomParams);
      this.messagesService.getUserChatRooms(this.chatRoomParams).subscribe({
        next: (response) => {
          if (response.result && response.pagination) {
            this.chatRooms?.push(...response.result);
            this.pagination = response.pagination;
          }
        },
      });
    }
  }
}
