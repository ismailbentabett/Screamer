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

  searchAlgolia(searchTerm: string): Promise<any> {
    return this.algoliaIndex.search(searchTerm);
  }
  constructor(
    private userService: UserService,
    private fb: FormBuilder,
    private commentService: CommentService
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
    console.log(this.post)
    const comment = {
      postId: this.post.id,
      content: this.form.value.comment,
      userId: this.currentUser.id,
      hashtags: this.hashtags ?? [],
      mentionsArr: this.mentions ?? [],
    };
      console.log(
        'Comment created successfully',
          comment
      )
    this.commentService.createComment(comment).subscribe((response: any) => {
      console.log('Comment created successfully', response);
      this.form.reset();
    });
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
