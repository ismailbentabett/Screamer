import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { User } from 'src/app/core/models/User';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { PostService } from 'src/app/core/services/post.service';
import {
  trigger,
  state,
  style,
  transition,
  animate,
} from '@angular/animations';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-add-post-form',
  templateUrl: './add-post-form.component.html',
  styleUrls: ['./add-post-form.component.scss'],
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
          display: 'none',

          transform: 'opacity-0 scale-95',
          opacity: 0,
        })
      ),
      transition('closed => open', animate('100ms ease-out')),
      transition('open => closed', animate('75ms ease-in')),
    ]),
  ],
})
export class AddPostFormComponent {
  user!: User;
  form: any;
  postId: any = null;
  baseUrl  = environment.baseWebApiUrl;
  postImageUrl: any = false;
  /**
   *
   */
  constructor(
    private authService: AuthenticationService,
    private postService: PostService,
    private fb: FormBuilder
  ) {
    this.authService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => {
        if (user) {
          this.user = user;
        }
      },
    });

    this.form = this.fb.group({
      /*    {
        "title": "string",
        "content": "string",
        "imageUrl": "string",
        "userId": "string" */
      title: ['', Validators.required],
      content: ['', Validators.required],
      imageUrl: ['placeholder url', Validators.required],
      userId: [this.user.id, Validators.required],
    });
  }

  createPost() {
    this.postService
      .createPost({
        userId: this.user.id,
        ...this.form.value,
      })
      .subscribe({
        next: (postId) => {
          this.postId = postId;
          this.postImageUrl = this.baseUrl + `Post/add-post-image/${this.postId}`
        },
      });
  }

  isAssignOpen = false;
  isLabelOpen = false;
  isDueDateOpen = false;

  toggleAssignDropdown() {
    this.isAssignOpen = !this.isAssignOpen;
  }
  toggleLabelDropdown() {
    this.isLabelOpen = !this.isLabelOpen;
  }
  toggleDueDateDropdown() {
    this.isDueDateOpen = !this.isDueDateOpen;
  }
}
