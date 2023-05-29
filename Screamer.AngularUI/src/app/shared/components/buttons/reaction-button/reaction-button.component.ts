import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { Component, Input } from '@angular/core';
import { take } from 'rxjs';
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
  reactionType: string | null = null;
  constructor(private reactionService: ReactionService) {}

  ngOnChanges(changes: any): void {
    if (changes['postId']) {
      this.reactionService
        .getPostReactionByPostAndUser(this.postId as number)
        .subscribe(() => {
          this.reactionService.currentUserPostReaction$
            .pipe(take(1))
            .subscribe({
              next: (reaction) => {
                console.log(this.postId, reaction);

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
