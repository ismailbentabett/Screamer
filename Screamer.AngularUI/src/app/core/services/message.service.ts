import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject, map, take } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BusyService } from './busy.service';
import { Message } from '../models/Message';
import {
  getPaginatedResult,
  getPaginationHeaders,
  getPaginationHeadersMessages,
  getThePaginationHeaders,
} from '../Helpers/paginationHelper';
import {
  HttpTransportType,
  HubConnection,
  HubConnectionBuilder,
} from '@microsoft/signalr';
import { User } from '../models/User';
import { Group } from '../models/Group';
import { ChatRoomParams } from '../models/ChatRoomParams';
import { MessageParams } from '../models/MessageParams';
import { UserService } from './user.service';
import { CreateMessage } from '../models/CreateMessage';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  baseUrl = environment.baseWebApiUrl;
  hubUrl = environment.hubUrl;
  private hubConnection?: HubConnection;
  private messageThreadSource = new BehaviorSubject<Message[]>([]);
  messageThread$ = this.messageThreadSource.asObservable();
  ChatRoomParams: ChatRoomParams | undefined;
  messageParams: MessageParams | undefined;
  constructor(
    private http: HttpClient,
    private busyService: BusyService,
    private userService: UserService
  ) {}

  getMessages(pageNumber: number, pageSize: number, container: string) {
    let params = getThePaginationHeaders(pageNumber, pageSize);
    params = params.append('Container', container);
    return getPaginatedResult<Message[]>(
      this.baseUrl + 'Message',
      params,
      this.http
    );
  }

  deleteMessage(id: number) {
    return this.http.delete(this.baseUrl + 'Message/' + id);
  }

  getChatRoomParams(userId: string, pageSize: number, pageNumber: number) {
    this.ChatRoomParams = new ChatRoomParams();
    this.ChatRoomParams.orderBy = 'UpdatedBy';
    this.ChatRoomParams.pageNumber = pageNumber;
    this.ChatRoomParams.pageSize = pageSize;
    this.ChatRoomParams.userId = userId;

    return this.ChatRoomParams;
  }

  setChatRoomParams(params: ChatRoomParams) {
    this.ChatRoomParams = params;
  }

  resetChatRoomParams(user: User) {
    if (user) {
      return (this.ChatRoomParams = new ChatRoomParams());
    }
    return;
  }
  getMessageParams(
    userId: string,
    pageSize: number,
    pageNumber: number,
    currentUserId: string
  ) {
    this.messageParams = new MessageParams();
    this.messageParams.orderBy = 'CreatedAt';
    this.messageParams.pageNumber = pageNumber;
    this.messageParams.pageSize = pageSize;
    this.messageParams.userId = userId;
    this.messageParams.currentUserId = currentUserId;
    return this.messageParams;
  }

  setMessageParams(params: MessageParams) {
    this.messageParams = params;
  }
  resetMessageParams(user: User) {
    if (user) {
      return (this.messageParams = new MessageParams());
    }
    return;
  }

  getMessageThread(messageParams: MessageParams) {
    let params = getPaginationHeadersMessages(
      messageParams.orderBy.toString(),
      messageParams.userId,
      messageParams.pageNumber,
      messageParams.pageSize,
      messageParams.currentUserId
    );
    return getPaginatedResult<Message[]>(
      this.baseUrl + 'Message/thread',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );
  }

  getUserChatRooms(chatRoomParams: ChatRoomParams) {
    let params = getPaginationHeaders(
      chatRoomParams.orderBy.toString(),
      chatRoomParams.userId,
      chatRoomParams.pageNumber,
      chatRoomParams.pageSize
    );
    return getPaginatedResult<Message[]>(
      this.baseUrl + 'Message/threads',
      params,
      this.http
    ).pipe(
      map((response: any) => {
        return response;
      })
    );
  }
  getChatRoomById(chatRoomId: number) {
    return this.http.get<Message[]>(
      this.baseUrl + 'Message/thread/' + chatRoomId
    );
  }

  private messageReceivedSubject = new Subject<any>();
  private userConnectedSubject = new Subject<any>();
  private userDisconnectedSubject = new Subject<any>();
  public istypingSubject = new Subject<boolean>();

  public istyping$: Observable<boolean> = this.istypingSubject.asObservable();



  messageReceived$: Observable<any> =
    this.messageReceivedSubject.asObservable();
  userConnected$: Observable<any> = this.userConnectedSubject.asObservable();
  userDisconnected$: Observable<any> =
    this.userDisconnectedSubject.asObservable();

  async startConnection(user: User, roomId: any): Promise<void> {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(
        this.hubUrl + 'message?=room' + roomId,

        {
          accessTokenFactory: () => user.token,
          transport: HttpTransportType.WebSockets,
        }
      )
      .withAutomaticReconnect()
      .build();

    await this.hubConnection.start().catch((err) => console.error(err));

    await this.hubConnection.on(
      'ReceiveMessage',
      (
        roomId: string,
        userId: string,
        RecipientId: string,
        Content: string
      ) => {
        this.messageReceivedSubject.next({
          roomId,
          senderId: userId,
          senderUsername: null,
          senderPhotoUrl: null,
          recipientId: RecipientId,
          recipientUsername: null,
          recipientPhotoUrl: null,
          content: Content,
          dateRead: null,
          messageSent: Date.now(),
        });
      }
    );

    this.hubConnection.on('UserConnected', (roomId: number, userId: string) => {
      this.userConnectedSubject.next({
        roomId,
        userId,
      });
    });

    this.hubConnection.on(
      'UserDisconnected',
      (roomId: number, userId: string) => {
        this.userDisconnectedSubject.next({
          roomId,
          userId,
        });
      }
    );
    this.hubConnection.on('typing', (data: boolean) => {
      console.log(
        'isTyping ',
        data
      )
      this.istypingSubject.next(data);
    });
  }

  sendMessage(roomId: string, createMessageDto: CreateMessage): void {
    this.hubConnection!.invoke('SendMessage', roomId, createMessageDto);
  }

  joinRoom(roomId: string): void {
    this.hubConnection!.invoke('JoinRoom', roomId);
  }

  leaveRoom(roomId: string): void {
    this.hubConnection!.invoke('LeaveRoom', roomId);
  }

  typing(roomId: string, isTyping: boolean): void {

    this.hubConnection!.invoke('Typing', roomId, isTyping);
  }
}
