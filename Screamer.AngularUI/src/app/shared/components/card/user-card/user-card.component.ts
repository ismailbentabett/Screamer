import { Component, Input } from '@angular/core';
import { take } from 'rxjs';
import { User } from 'src/app/core/models/User';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.scss'],
})
export class UserCardComponent {
  @Input() user!: User | any;

  /**
   *
   */
  constructor() {

  }

  //oninit void
  ngOnInit(): void {}
}
