import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatRoomComponent } from './chat-room/chat-room.component';
import { ChatListComponent } from './chat-list/chat-list.component';
import { ChatComponent } from './chat/chat.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: ChatRoomComponent,

        children: [
          {
            path: 'room/:roomId',
            component: ChatComponent,
          },
        ],
      },
      {
        path: 'list',
        component: ChatListComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ChatRoutingModule {}
