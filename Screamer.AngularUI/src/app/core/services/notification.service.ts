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

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  baseUrl = environment.baseWebApiUrl;
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

  constructor(private http: HttpClient) {}

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

    await this.hubConnection.on('ReceiveNotification', () => {
      this.notificationRecievedSubject.next({});
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

  sendNotification(roomId: string, CreateNotificationDto: any): void {
    this.hubConnection!.invoke(
      'SendNotification',
      roomId,
      CreateNotificationDto
    );
  }

  joinRoom(roomId: string): void {
    this.hubConnection!.invoke('JoinRoom', roomId);
  }

  leaveRoom(roomId: string): void {
    this.hubConnection!.invoke('LeaveRoom', roomId);
  }
}
