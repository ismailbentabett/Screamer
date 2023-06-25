import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NotificationRoutingModule } from './notification-routing.module';
import { NotificationPageComponent } from './notification-page/notification-page.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [NotificationPageComponent],
  imports: [CommonModule, NotificationRoutingModule, SharedModule],
})
export class NotificationModule {}
