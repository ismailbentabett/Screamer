import {
  Component,
  Inject,
  Input,
  PLATFORM_ID,
  SimpleChange,
  ViewChild,
} from '@angular/core';
import { Post } from 'src/app/core/models/Post';
import {
  trigger,
  state,
  style,
  transition,
  animate,
} from '@angular/animations';
import { UserService } from 'src/app/core/services/user.service';
import { User } from 'src/app/core/models/User';
import { filter, take } from 'rxjs';
import { ClipboardService } from 'ngx-clipboard';
import { LocationStrategy, isPlatformBrowser } from '@angular/common';
import { NavigationEnd, Router } from '@angular/router';
import { QuillEditorComponent } from 'ngx-quill';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import 'quill-mention';

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
  currentUser!: User;
  user!: User;
  @ViewChild(QuillEditorComponent, { static: true })
  editor!: QuillEditorComponent;
  constructor(
    private userService: UserService,
    private clipboardService: ClipboardService,
    @Inject(PLATFORM_ID) private platformId: Object,
    private router: Router,
    private sanitizer: DomSanitizer
  ) {
    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.currentUser = user;
        },
      });
  }

  getSanitizedContent(content: string): SafeHtml {
    return this.sanitizer.bypassSecurityTrustHtml(content);
  }

  isMyPost() {
    return this.currentUser?.id == this.post.userId;
  }

  isOnCurrentPost() {
    return this.router.url == '/v/post/' + this.post.id;
  }
  getAppPath(): string {
    if (isPlatformBrowser(this.platformId)) {
      return window.location.origin;
    } else {
      // Handle server-side rendering scenario if applicable
      return ''; // or any default value
    }
  }
  isCopied: boolean = false;
  copyPostLink() {
    this.clipboardService.copyFromContent(
      this.getAppPath() + '/v/post/' + this.post.id
    );
    this.isCopied = true;
    setTimeout(() => {
      this.isCopied = false;
    }, 1000);
  }
  ngOnChanges(changes: any): void {
    if (changes['post'] && this.post) {
      this.userService.getUserById(this.post.userId.toString()).subscribe({
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

  modules = {
    toolbar: false,
    mention: {
      positioningStrategy: 'fixed',
      mentionListClass: 'ql-mention-list shadow-lg ',
      allowedChars: /^[A-Za-z\sÅÄÖåäö]*$/,
      showDenotationChar: false,
      spaceAfterInsert: false,
      mentionDenotationChars: ['@', '#'],
      linkTarget: '_blank',
    },
  };
}
