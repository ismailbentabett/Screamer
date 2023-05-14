import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { ProfileComponent } from './profile/profile.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgxSpinnerModule } from 'ngx-spinner';


@NgModule({
  declarations: [
    ProfileComponent
  ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    SharedModule,
    NgxSpinnerModule

  ]
})
export class AccountModule { }
