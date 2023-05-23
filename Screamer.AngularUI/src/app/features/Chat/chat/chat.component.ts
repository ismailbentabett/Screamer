import {
  Component,
  ElementRef,
  Input,
  QueryList,
  ViewChild,
  ViewChildren,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  ActivatedRoute,
  NavigationEnd,
  Params,
  Router,
  RouterLinkActive,
} from '@angular/router';
import { Subscription, take } from 'rxjs';
import { CreateMessage } from 'src/app/core/models/CreateMessage';
import { Message } from 'src/app/core/models/Message';
import { MessageParams } from 'src/app/core/models/MessageParams';
import { Pagination } from 'src/app/core/models/Pagination';
import { User } from 'src/app/core/models/User';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { BusyService } from 'src/app/core/services/busy.service';
import { MessageService } from 'src/app/core/services/message.service';
import { UserService } from 'src/app/core/services/user.service';
import { ScrollToBottomDirective } from 'src/app/shared/directives/scrol-to-bottom.directive';

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
  pageSize = 15;
  pagination: Pagination | undefined;
  messageParams: MessageParams | undefined;
  next: string | undefined;
  userId?: string;
  user!: User;
  currentUserId?: string;
  currentUser!: User;
  someSubscription: any;

  selector: string = '#chatClass';
  newMessage!: string;
  private messageSubscription!: Subscription;
  realTimeMessages: Message[] = [];
  @ViewChild('chatRef', { static: false }) chatRef!: ElementRef;
  @ViewChild(ScrollToBottomDirective)
  scroll!: ScrollToBottomDirective;
  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private messagesService: MessageService,
    private userService: UserService,
    private router: Router,
    private busyService: BusyService,
    private authService: AuthenticationService
  ) {
    this.form = this.fb.group({
      message: ['', Validators.required],
    });

    router.events.subscribe((val) => {
      // see also
      this.route.paramMap.subscribe(async (params) => {
        let roomId = params.get('roomId');
        this.messagesService.leaveRoom(roomId as string);
      });
    });
  }
  ngOnInit(): void {
    this.authService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => {
        if (user) {
          this.route.paramMap.subscribe(async (params) => {
            let roomId = params.get('roomId');
            await this.messagesService.startConnection(user, roomId);
            this.messageSubscription =
              this.messagesService.messageThread$.subscribe({
                next: (messages) => {
                  this.messages = messages;
                },
              });

            //join the room
            this.messagesService.joinRoom(roomId as any);

            this.messagesService.messageReceived$.subscribe({
              next: (message: Message) => {
                this.messages?.unshift(
                  message
                )

              },
            });
          });
        }
      },
    });

    this.route.paramMap.subscribe((params) => {
      let roomId = params.get('roomId');
      this.getChatRoomById(roomId);
    });
    this.scrollToBottom();
  }
  ngOnDestroy(): void {
    this.messageSubscription.unsubscribe();
  }
  @ViewChildren('messageContainer') messageContainers!: QueryList<ElementRef>;

  ngAfterViewInit() {
    this.scrollToBottom(); // For messsages already present
    this.messageContainers.changes.subscribe((list: QueryList<ElementRef>) => {
      this.scrollToBottom(); // For messages added later
    });
  }

  scrollToBottom(): void {
    if (this.chatRef && this.chatRef.nativeElement) {
      const chatContainer = this.chatRef.nativeElement;
      chatContainer.scrollTop = chatContainer.scrollHeight;
    }
  }

  toggleEmojiMart(): void {
    this.emojiMartVisible = !this.emojiMartVisible;
  }
  addEmoji($event: { emoji: { native: any } }) {
    let data = this.form.get('message');
    data!.patchValue(data!.value + $event.emoji.native);
  }

  getChatRoomById(roomId: any) {
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
    this.busyService.busy();
    if (this.messageParams) {
      this.messagesService.setMessageParams(this.messageParams);
      this.messagesService.getMessageThread(this.messageParams).subscribe({
        next: (response) => {
          if (response.result && response.pagination) {
            this.messages = response.result;
            this.pagination = response.pagination;
            this.busyService.idle();
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
    this.newMessage = this.form.get('message')?.value;
    /* createMessageDto: CreateMessage, roomId: string */

    if (this.newMessage) {
      let createMessageDto: CreateMessage = {
        content: this.newMessage,
        userId: this.currentUserId as string,
        recipientId: this.userId as string,
      };
      this.messagesService.sendMessage(
        this.room.id as string,

        createMessageDto
      );
      this.newMessage = '';

      this.form.reset();
    }
  }

  getClassNames(message: any, currentUser: any) {
    if (message.senderId !== currentUser.id) {
      return 'flex flex-row items-center';
    } else {
      return 'flex items-center justify-start flex-row-reverse';
    }
  }
}
