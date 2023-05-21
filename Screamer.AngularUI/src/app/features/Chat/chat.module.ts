import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChatRoutingModule } from './chat-routing.module';
import { ChatRoomComponent } from './chat-room/chat-room.component';
import { ChatListComponent } from './chat-list/chat-list.component';

import { PickerComponent } from '@ctrl/ngx-emoji-mart';
import { ReactiveFormsModule } from '@angular/forms';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';

@NgModule({
  declarations: [
    ChatRoomComponent,
    ChatListComponent,
  ],
  imports: [
    CommonModule,
    ChatRoutingModule,
    PickerComponent,
    ReactiveFormsModule,
    InfiniteScrollModule,

  ]
})
export class ChatModule { }
