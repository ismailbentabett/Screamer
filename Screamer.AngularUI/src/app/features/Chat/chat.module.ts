import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChatRoutingModule } from './chat-routing.module';
import { ChatRoomComponent } from './chat-room/chat-room.component';
import { ChatListComponent } from './chat-list/chat-list.component';

import { PickerComponent } from '@ctrl/ngx-emoji-mart';
import { ReactiveFormsModule } from '@angular/forms';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { SharedModule } from 'src/app/shared/shared.module';
import { ChatComponent } from './chat/chat.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ScrollToBottomDirective } from 'src/app/shared/directives/scrol-to-bottom.directive';

@NgModule({
  declarations: [
    ChatRoomComponent,
    ChatListComponent,
    ChatComponent,
    ScrollToBottomDirective
  ],
  imports: [
    CommonModule,
    ChatRoutingModule,
    PickerComponent,
    ReactiveFormsModule,
    InfiniteScrollModule,
    SharedModule,
    NgxSpinnerModule,


  ]
})
export class ChatModule { }
