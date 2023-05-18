import { Component, Input } from '@angular/core';
import { User } from 'src/app/core/models/User';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-follow-card',
  templateUrl: './follow-card.component.html',
  styleUrls: ['./follow-card.component.scss'],
})
export class FollowCardComponent {
  @Input() follow: any | null = null;
  user: User | null = null;
  /**
   *
   */
  constructor(private userService: UserService) {}
  ngOnInit(): void {
console.log(this.follow)
    this.userService.getUserById(this.follow!.userId).subscribe({
      next: (data) => {
        this.user = data;
      },
    });
  }
}
