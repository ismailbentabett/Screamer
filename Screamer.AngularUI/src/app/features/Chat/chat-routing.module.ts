import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatRoomComponent } from './chat-room/chat-room.component';
import { ChatComponent } from './chat/chat.component';

const routes: Routes = [
  {
    path: '',
    component: ChatRoomComponent,
    children: [
      {
        path: ':roomId',
        component: ChatComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ChatRoutingModule {}
