import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpTransportType, HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject, take } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class PresenceService {

  hubUrl = environment.hubUrl;
  private hubConnection?: HubConnection;
  private onlineUsersSource = new BehaviorSubject<string[]>([]);
  onlineUsers$ = this.onlineUsersSource.asObservable();

  constructor(private router: Router) { }

  createHubConnection(user: User) {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.hubUrl + 'presence', {
        accessTokenFactory: () => user.token,
        transport: HttpTransportType.WebSockets
      })
      .withAutomaticReconnect()
      .build();

    this.hubConnection.start().catch((error: any) => console.log(error));

    this.hubConnection.on('UserIsOnline', (userId: any) => {
      this.onlineUsers$.pipe(take(1)).subscribe({
        next: (userIds: any) => this.onlineUsersSource.next([...userIds, userId])
      })
    })

    this.hubConnection.on('UserIsOffline', (userId: any) => {
      this.onlineUsers$.pipe(take(1)).subscribe({
        next: (userIds: any[]) => this.onlineUsersSource.next(userIds.filter((x: any) => x !== userId))
      })
    })

    this.hubConnection.on('GetOnlineUsers', (userIds: any) => {

      this.onlineUsersSource.next(userIds);
    })

    this.hubConnection.on('NewMessageReceived', ({userId, knownAs}) => {
   /*    this.toastr.info(knownAs + ' has sent you a new message! Click me to see it')
        .onTap
        .subscribe({
          next: () => this.router.navigateByUrl('/members/' + userId + '?tab=Messages')
        }) */
/*         console.log(knownAs + ' has sent you a new message! Click me to see it')
 */    })
  }

  stopHubConnection() {
    this.hubConnection?.stop().catch((error: any) => console.log(error));
  }
}
