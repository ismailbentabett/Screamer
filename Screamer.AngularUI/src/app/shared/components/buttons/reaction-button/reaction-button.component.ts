import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { Component, Input } from '@angular/core';
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
  reaction!: string;
  @Input()
  postId!: number;
  constructor(private reactionService: ReactionService) {}
  isOpen = false;

  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }

  react(reactionType: string) {
    this.reactionService
      .addPostReaction(this.postId, reactionType)
      .subscribe(() => {
        this.reaction = reactionType;
        this.toggleDropdown();
      });
  }
}
