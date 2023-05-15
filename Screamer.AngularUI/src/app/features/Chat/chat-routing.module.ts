import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatRoomComponent } from './chat-room/chat-room.component';
import { ChatListComponent } from './chat-list/chat-list.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'room',
        component: ChatRoomComponent,
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
