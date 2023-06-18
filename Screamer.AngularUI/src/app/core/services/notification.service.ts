import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  HttpTransportType,
  HubConnection,
  HubConnectionBuilder,
} from '@microsoft/signalr';
import { environment } from 'src/environments/environment';
import { User } from '../models/User';
import { BehaviorSubject, Observable, Subject, map, take } from 'rxjs';
import { CreateNotificationDto } from '../models/CreateNotificationDto';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  hubUrl = environment.hubUrl;
  private hubConnection?: HubConnection;
  private notificationRecievedSubject = new Subject<any>();

  notificationRecieved$: Observable<any> =
    this.notificationRecievedSubject.asObservable() as any;

  private userConnectedSubject = new Subject<any>();
  userConnected$: Observable<any> = this.userConnectedSubject.asObservable();
  private userDisconnectedSubject = new Subject<any>();

  userDisconnected$: Observable<any> =
    this.userDisconnectedSubject.asObservable();

  constructor(private http: HttpClient , private toastr: ToastrService) {}

  async startConnection(user: User, roomId: any): Promise<void> {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(
        this.hubUrl + 'notification?room=' + roomId,

        {
          accessTokenFactory: () => user.token,
          transport: HttpTransportType.WebSockets,
        }
      )
      .withAutomaticReconnect()
      .build();

    await this.hubConnection
      .start()
      .catch((err) => console.error(err));

    await this.hubConnection.on('ReceiveNotification', (roomId , data) => {
      console.log(data);
      this.toastr.info(data, 'Notification');
      this.notificationRecievedSubject.next(
        data
      );
    });

    await this.hubConnection.on('JoinRoom', (data: any) => {});
    await this.hubConnection.on('Room', (data: any) => {
      this.joinRoom(roomId as any);
    });
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
  }

  sendNotification(
    roomId: string,
    CreateNotificationDto: CreateNotificationDto
  ): void {
    this.hubConnection!.invoke(
      'SendNotification',
      roomId,

      CreateNotificationDto.message,
      CreateNotificationDto.type,
      CreateNotificationDto.chatRoomId,
      CreateNotificationDto.notificationRoomId,
      CreateNotificationDto.postId,
      CreateNotificationDto.senderId,
      CreateNotificationDto.recieverId,
      CreateNotificationDto.commentId,
      CreateNotificationDto.replyId,
      CreateNotificationDto.reactionId,
      CreateNotificationDto.tagId,
      CreateNotificationDto.mentionId,
      CreateNotificationDto.isRead
    );
  }

  joinRoom(roomId: string): void {
    this.hubConnection!.invoke('JoinRoom', roomId);
  }

  leaveRoom(roomId: string): void {
    this.hubConnection!.invoke('LeaveRoom', roomId);
  }
}
