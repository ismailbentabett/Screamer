import { Component, Input, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import algoliasearch from 'algoliasearch';
import { QuillEditorComponent } from 'ngx-quill';
import 'quill-mention';
import * as linkify from 'linkifyjs';
import 'linkify-plugin-keyword';
import 'linkify-plugin-hashtag';
import 'linkify-plugin-mention';
import 'linkify-plugin-ticket';
import 'linkify-plugin-ip';
import { uniq } from 'lodash';
import { UserService } from 'src/app/core/services/user.service';
import { FormBuilder, FormControl } from '@angular/forms';
import { take } from 'rxjs';
import { CommentService } from 'src/app/core/services/comment.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { CreateNotificationDto } from 'src/app/core/models/CreateNotificationDto';

@Component({
  selector: 'app-comment-input',
  templateUrl: './comment-input.component.html',
  styleUrls: ['./comment-input.component.scss'],
})
export class CommentInputComponent {
  @ViewChild(QuillEditorComponent, { static: true })
  editor!: QuillEditorComponent;
  algoliaClient = algoliasearch(environment.ApplicationId, environment.APIKey);
  algoliaIndex = this.algoliaClient.initIndex('user');
  currentUser: any;
  form: any;
  hashtags: string[] = [];
  mentions: string[] = [];
  tickets: string[] = [];
  ips: string[] = [];
  keywords: string[] = [];
  @Input() post: any;
  @Input() parentCommentId: any = null;
  @Input () comment : any;

  searchAlgolia(searchTerm: string): Promise<any> {
    return this.algoliaIndex.search(searchTerm);
  }
  constructor(
    private userService: UserService,
    private fb: FormBuilder,
    private commentService: CommentService,
    private notificationService: NotificationService
  ) {
    this.userService
      .getCurrentUserData()
      .pipe(take(1))
      .subscribe({
        next: (user: any) => {
          this.currentUser = user;
        },
      });

    this.form = this.fb.group({
      comment: new FormControl(''),
    });
  }
  analyzeText() {}
  ngOnInit(): void {
    this.form.valueChanges.subscribe((x: any) => {
      this.hashtags = linkify
        .find(x.comment, 'hashtag')
        .map((link) => link.value);
      this.mentions = linkify
        .find(x.comment, 'mention')
        .map((link) => link.value);
      this.tickets = linkify
        .find(x.comment, 'ticket')
        .map((link) => link.value);
      this.ips = linkify.find(x.comment, 'ip').map((link) => link.value);
      this.keywords = linkify
        .find(x.comment, 'keyword')
        .map((link) => link.value);

      //make values unique and remove the @ from mentions
      this.mentions = uniq(
        this.mentions.map((mention) => mention.replace('@', ''))
      );

      this.hashtags = uniq(this.hashtags);
    });
  }

  createComment() {
    const comment = {
      postId: this.post.id,
      content: this.form.value.comment,
      userId: this.currentUser.id,
      hashtags: this.hashtags ?? [],
      mentionsArr: this.mentions ?? [],
    };

    this.commentService.createComment(comment).subscribe((response: any) => {
      console.log(response);
      this.notificationService.sendNotification(
        this.currentUser.id.toString(),
        {
          message: `${this.currentUser.userName} has Commented on your post`,
          type: 'Comment',
          chatRoomId: 0,
          notificationRoomId: this.currentUser.id.toString(),
          postId: this.post.id,
          senderId: this.currentUser.id.toString(),
          recieverId: this.post.userId.toString(),
          commentId: response,
          replyId: 0,
          reactionId: 0,
          tagId: 0,
          mentionId: 0,
          isRead: true,
        } as CreateNotificationDto
      );
      console.log({
        message: `${this.currentUser.userName} has Commented on your post`,
        type: 'Comment',
        chatRoomId: 0,
        notificationRoomId: this.currentUser.id.toString(),
        postId: this.post.id,
        senderId: this.currentUser.id.toString(),
        recieverId: this.post.userId.toString(),
        commentId: response,
        replyId: 0,
        reactionId: 0,
        tagId: 0,
        mentionId: 0,
        isRead: true,
      } as CreateNotificationDto);


      this.form.reset();
    });
  }

  createReply() {
    const reply = {
      parentCommentId: this.parentCommentId,
      postId: this.post.id,
      content: this.form.value.comment,
      userId: this.currentUser.id,
      hashtags: this.hashtags ?? [],
      mentionsArr: this.mentions ?? [],
    };
console.log(this.comment)
    this.commentService.createReply(reply).subscribe((response: any) => {
      this.notificationService.sendNotification(
        this.currentUser.id.toString(),
        {
          message: `${this.currentUser.userName} has Replied To your Comment`,
          type: 'Reply',
          chatRoomId: 0,
          notificationRoomId: this.currentUser.id.toString(),
          postId: this.post.id,
          senderId: this.currentUser.id.toString(),
          recieverId: this.comment.user.id.toString(),
          commentId: this.parentCommentId,
          replyId: response,
          reactionId: 0,
          tagId: 0,
          mentionId: 0,
          isRead: true,
        } as CreateNotificationDto
      );
      console.log(
        {
          message: `${this.currentUser.userName} has Replied To your Comment`,
          type: 'Reply',
          chatRoomId: 0,
          notificationRoomId: this.currentUser.id.toString(),
          postId: this.post.id,
          senderId: this.currentUser.id.toString(),
          recieverId: this.comment.user.id.toString(),
          commentId: this.parentCommentId,
          replyId: response,
          reactionId: 0,
          tagId: 0,
          mentionId: 0,
          isRead: true,
        }
      )
      this.form.reset();
    });
  }

  create() {
    if (this.parentCommentId && this.parentCommentId !== null) {
      this.createReply();
    } else {
      this.createComment();
    }
  }
  modules = {
    toolbar: false,
    mention: {
      positioningStrategy: 'fixed',
      mentionListClass: 'ql-mention-list shadow-lg ',
      allowedChars: /^[A-Za-z\sÅÄÖåäö]*$/,
      showDenotationChar: false,
      spaceAfterInsert: false,
      mentionDenotationChars: ['@', '#'],
      linkTarget: '_self',
      onSelect: (item: any, insertItem: any) => {
        const editor = this.editor.quillEditor;
        insertItem(item);
        editor.insertText(editor.getLength() - 1, '', 'user');
      },
      source: (searchTerm: any, renderList: any, mentionChar: string) => {
        if (mentionChar === '@') {
          // Handle user mentions
          const index = this.algoliaClient.initIndex('user');

          index
            .search(searchTerm)
            .then((response) => {
              const matches = response.hits.map((hit: any) => {
                const displayValue = `<span class="text-dodger-blue-500 font-black	 no-underline">@${hit.userName}</span>`;
                const mentionValue = `<span class="text-dodger-blue-500 font-black	 no-underline">@${hit.userName}</span>`;

                const link = `/v/user/${hit.objectID}`;
                return { id: hit.objectID, value: displayValue, link };
              });
              renderList(matches, searchTerm);
            })
            .catch((error) => {
              console.error('Algolia search error:', error);
              renderList([], searchTerm);
            });
        } else if (mentionChar === '#') {
          // Handle hashtags
          const hashtagItems = [
            {
              id: 'hashtag',
              value: `<span class="text-dodger-blue-500 font-black	 no-underline">#${searchTerm}</span>`,
              link: `/v/hashtag/#${searchTerm}`,
            },
          ];
          renderList(hashtagItems, searchTerm);
        }
      },
    },
  };
}
