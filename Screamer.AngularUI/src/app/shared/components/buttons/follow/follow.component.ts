import { Component, Input } from '@angular/core';
import { take } from 'rxjs';
import { FollowParams } from 'src/app/core/models/FollowParams';
import { User } from 'src/app/core/models/User';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-follow',
  templateUrl: './follow.component.html',
  styleUrls: ['./follow.component.scss']
})
export class FollowComponent {
  @Input () targetUser ! : User;
   sourceUser! : User;
   followeParams! : FollowParams
   followers : any;
    followings : any;

constructor(
  private userService : UserService
) {
  this.userService
  .getCurrentUserData()
  .pipe(take(1))
  .subscribe({
    next: (user: any) => {
      this.sourceUser = user;
    },
  });

}

ngOnInit(): void {
  this.followers = this.userService.getUserFollowers(
    this.targetUser.id as any
  )
  this.followings = this.userService.getUserFollowing(
    this.targetUser.id as any
  )

}

follow() {
  this.userService.addFollow(
    this.sourceUser!.id as any,
    this.targetUser!.id as any
  ).
  subscribe({
    next: () => {
     console.log(
        "followed"
     )
    }
  })


}

unfollow() {
  this.userService.removeFollow(
    this.sourceUser!.id as any,
    this.targetUser!.id as any
  ).
  subscribe({
    next: () => {
     console.log(
        "unfollowed"
     )
    }
  })
  }


}
