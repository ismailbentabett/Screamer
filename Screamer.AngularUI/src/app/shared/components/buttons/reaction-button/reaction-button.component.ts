import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { Component, Input } from '@angular/core';
import { take } from 'rxjs';
import { CreateNotificationDto } from 'src/app/core/models/CreateNotificationDto';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { ReactionService } from 'src/app/core/services/reaction.service';

@Component({
  selector: 'app-reaction-button',
  templateUrl: './reaction-button.component.html',
  styleUrls: ['./reaction-button.component.scss'],
  animations: [
    trigger('dropdownAnimation', [
      state(
        'open',
        style({
          transform: 'opacity-100 scale-100',
          opacity: 1,
        })
      ),
      state(
        'closed',
        style({
          transform: 'opacity-0 scale-95',
          opacity: 0,
        })
      ),
      transition('closed => open', animate('100ms ease-out')),
      transition('open => closed', animate('75ms ease-in')),
    ]),
  ],
})
export class ReactionButtonComponent {
  reaction!: any;
  @Input()
  postId: number | null = null;
  @Input() post: any;
  reactionType: string | null = null;
  constructor(
    private reactionService: ReactionService,
    private notificationService: NotificationService,
    private authService: AuthenticationService
  ) {}

  ngOnChanges(changes: any): void {
    if (changes['postId']) {
      this.reactionService
        .getPostReactionByPostAndUser(this.postId as number)
        .subscribe(() => {
          this.reactionService.currentUserPostReaction$
            .pipe(take(1))
            .subscribe({
              next: (reaction) => {
                if (reaction && reaction.postId == this.postId) {
                  this.reaction = reaction;
                  this.reactionType = reaction.reactionType;
                }
              },
            });
        });
    }
  }

  isOpen = false;

  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }

  react(reactionType: string) {
    this.reactionService
      .addPostReaction(this.postId as number, reactionType)
      .subscribe((data: any) => {
        this.reactionType = data.reactionType;
        this.reaction = data;
        this.toggleDropdown();

        this.authService.currentUser$.pipe(take(1)).subscribe({
          next: (user: any) => {
            if (user) {
              this.notificationService.sendNotification(user.id.toString(), {
                message: `${user.userName} Has Added a ${reactionType} Reaction your post`,
                type: 'Reply',
                chatRoomId: 0,
                notificationRoomId: user.id.toString(),
                postId: this.postId,
                senderId: user.id.toString(),
                recieverId: this.post.userId.toString(),
                commentId: 0,
                replyId: 0,
                reactionId: 0,
                tagId: 0,
                mentionId: 0,
                isRead: true,
              } as CreateNotificationDto);
              console.log({
                message: `${user.userName} Has Added a ${reactionType} Reaction your post`,
                type: 'Reply',
                chatRoomId: 0,
                notificationRoomId: user.id.toString(),
                postId: this.postId,
                senderId: user.id.toString(),
                recieverId: this.post.userId.toString(),
                commentId: 0,
                replyId: 0,
                reactionId: 0,
                tagId: 0,
                mentionId: 0,
                isRead: true,
              });
            }
          },
        });
      });
  }

  removeReaction() {
    this.reactionService
      .deletePostReaction(
        this.postId as number,
        this.reactionType as string,
        this.reaction.id
      )
      .subscribe(() => {
        this.reactionType = null;
      });
  }
}
