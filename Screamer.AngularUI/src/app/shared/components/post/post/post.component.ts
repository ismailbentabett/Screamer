import { Component, Input, SimpleChange } from '@angular/core';
import { Post } from 'src/app/core/models/Post';
import {
  trigger,
  state,
  style,
  transition,
  animate,
} from '@angular/animations';
import { UserService } from 'src/app/core/services/user.service';
import { BusyService } from 'src/app/core/services/busy.service';
import { User } from 'src/app/core/models/User';
import { take } from 'rxjs';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
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
export class PostComponent {
  @Input() post!: Post;
  @Input() preview: boolean = false;

  user!: User;
  constructor(
    private userService: UserService,
    private busyService: BusyService
  ) {}

  ngOnChanges(changes: any): void {
    if (changes['post']) {
      this.userService
        .getUserById(this.post.userId.toString())
        .subscribe({
          next: (user: any) => {
            this.user = user;
          },
        });
    }
  }
  isOpen = false;

  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }
  isCommentsOpen = false;

  toggleCommentSection() {
    this.isCommentsOpen = !this.isCommentsOpen;
  }

  public slides = [
    {
      src: 'https://images.unsplash.com/photo-1684525749135-2ad4a531a04e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80',
    },
    {
      src: 'https://images.unsplash.com/photo-1684867933974-af23d25d6d00?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80',
    },
  ];
}
