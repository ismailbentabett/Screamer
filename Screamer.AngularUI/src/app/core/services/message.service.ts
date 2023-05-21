import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, take } from 'rxjs';
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
  constructor(private http: HttpClient, private busyService: BusyService) {}

  createHubConnection(user: User, otherUsername: string) {
    this.busyService.busy();
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.hubUrl + 'message?user=' + otherUsername, {
        accessTokenFactory: () => user.token,
        transport: HttpTransportType.WebSockets,
      })
      .withAutomaticReconnect()
      .build();

    this.hubConnection
      .start()
      .catch((error) => console.log(error))
      .finally(() => this.busyService.idle());

    this.hubConnection.on('ReceiveMessageThread', (messages) => {
      this.messageThreadSource.next(messages);
    });

    this.hubConnection.on('UpdatedGroup', (group: Group) => {
      if (group.connections.some((x) => x.username === otherUsername)) {
        this.messageThread$.pipe(take(1)).subscribe({
          next: (messages) => {
            messages.forEach((message) => {
              if (!message.dateRead) {
                message.dateRead = new Date(Date.now());
              }
            });
            this.messageThreadSource.next([...messages]);
          },
        });
      }
    });

    this.hubConnection.on('NewMessage', (message) => {
      this.messageThread$.pipe(take(1)).subscribe({
        next: (messages) => {
          this.messageThreadSource.next([...messages, message]);
        },
      });
    });
  }

  stopHubConnection() {
    if (this.hubConnection) {
      this.messageThreadSource.next([]);
      this.hubConnection.stop();
    }
  }

  getMessages(pageNumber: number, pageSize: number, container: string) {
    let params = getThePaginationHeaders(pageNumber, pageSize);
    params = params.append('Container', container);
    return getPaginatedResult<Message[]>(
      this.baseUrl + 'Message',
      params,
      this.http
    );
  }

  async sendMessage(userId: string, recipientId: string, content: string) {
    return this.hubConnection
      ?.invoke('SendMessage', {
        recipientId,
        content,
        userId,
      })
      .catch((error) => console.log(error));
  }

  deleteMessage(id: number) {
    return this.http.delete(this.baseUrl + 'Message/' + id);
  }

  /* GetUserChatRooms *
  https://localhost:5001/api/Message/threads?userId=9e224968-33e4-4652-b7b7-8574d048cdb9
  */

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
}
