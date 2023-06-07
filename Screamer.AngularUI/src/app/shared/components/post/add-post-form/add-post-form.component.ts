import { Component, Input, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
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
import { CategoryService } from 'src/app/core/services/category.service';

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
  @Input() post: any = null;
  @Input() edit: boolean = false;

  user!: User;
  form: any;
  postId: any = null;
  baseUrl = environment.baseWebApiUrl;
  postImageUrl: any = false;
  preview: any = false;
  hashtags: string[] = [];
  mentions: string[] = [];
  tickets: string[] = [];
  ips: string[] = [];
  keywords: string[] = [];
  moodType!: string;
  categoriesArray: string[] = [];
  tagsArray: string[] = [];
  isMoodOpen = false;
  openTab = 1;
  emojiMartVisible: any;
  isFocused: boolean = false;
  isTitleFocused: boolean = false;
  ShowContentErrors: boolean = false;
  ShowTitleErrors: boolean = false;

  /**
   *
   */
  constructor(
    private authService: AuthenticationService,
    public postService: PostService,
    private fb: FormBuilder,
    private categoryService: CategoryService
  ) {
    this.authService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => {
        if (user) {
          this.user = user;
        }
      },
    });

    this.form = this.fb.group({
      title: [
        '',
        [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(300),
        ],
      ],
      content: new FormControl(
        '',

        [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(1000000),
        ]
      ),

      imageUrl: ['placeholder url', Validators.required],
      userId: [this.user.id, Validators.required],
    });
  }

  toggleEmojiMart(): void {
    this.emojiMartVisible = !this.emojiMartVisible;
  }

  ngOnChanges(changes: any): void {
    if (changes.edit.currentValue == true && this.post) {
      var categories = changes.post.currentValue.postCategories.map(
        (x: any) => x.category.name
      );
      var mentions = changes.post.currentValue.mentions.map(
        (x: any) => x.user.userName
      );
      var hashtag = changes.post.currentValue.postHashtags.map(
        (x: any) => x.hashtag.name
      );
      var tags = changes.post.currentValue.tags.map((x: any) => x.user);

      this.form.patchValue(changes.post.currentValue);
      this.preview = changes.post.currentValue;
      this.preview.content = changes.post.currentValue.content ?? '';
      this.previewImages = changes.post.currentValue.postImages;
      this.postImageUrl = changes.post.currentValue.imageUrl;
      this.moodType = changes.post.currentValue.mood.moodType;
      this.hashtags = hashtag;
      this.mentions = mentions;
      this.categoryService.addedCategories = categories;
      this.postService.tagSearchResultArray = tags;
      this.postId = changes.post.currentValue.id;
    }
  }

  addEmoji($event: { emoji: { native: any } }) {
    const emojiNative = $event.emoji.native;

    let data = this.form.get('content');
    const existingContent = data!.value;
    const updatedContent = existingContent.replace(
      '</p>',
      `${emojiNative}</p>`
    );
    data!.patchValue(updatedContent);
  }

  addTag(tag: any) {
    this.tagsArray.push(tag);
  }

  react(moodType: string) {
    this.moodType = moodType;
  }
  createPost() {
    const mainform = document.querySelector('.mainform');
    const titleControl = this.form.get('title');
    const contentControl = this.form.get('content');
    if (!this.form.valid) {
      //get the add-post class div
      const addPost = document.querySelector('.add-post');
      //add the error class to the div
      addPost?.classList.add('shake');

      mainform?.classList.add('border-red-300');
      mainform?.classList.add('border-2');

      //after a time remove it
      setTimeout(() => {
        addPost?.classList.remove('shake');
      }, 200);

      if (
        titleControl?.errors?.required ||
        titleControl?.errors?.minlength ||
        titleControl?.errors?.maxlength
      )
        this.ShowTitleErrors = true;

      if (
        contentControl?.errors?.required ||
        contentControl?.errors?.minlength ||
        contentControl?.errors?.maxlength
      )
        this.ShowContentErrors = true;
      return;
    }
    this.ShowContentErrors = false;
    this.ShowTitleErrors = false;
    mainform?.classList.remove('border-red-300');
    mainform?.classList.remove('border-2');
    this.postService
      .createPost({
        userId: this.user.id,
        ...this.form.value,
        moodType: this.moodType ?? null,
        hashtags: this.hashtags ?? null,
        mentionsArr: this.mentions ?? null,
        categories: this.categoryService.addedCategories ?? null,
        tagsArr: this.postService.gettagSearchResultArrayUsernames() ?? null,
      })
      .subscribe({
        next: (postId) => {
          this.postId = postId;

          this.postService.sendpostImageUrl(postId);
        },
      });

    /*    this.postService
      .updatePost({
        userId: this.user.id,
        ...this.form.value,
        mood: this.moodType ?? null,
        hashtags: this.hashtags ?? null,
        mentions: this.mentions ?? null,
        categories: this.categoryService.addedCategories ?? null,
        tags: this.postService.gettagSearchResultArrayUsernames() ?? null,
      })
      .subscribe({
        next: (postId) => {
          this.postId = postId;

          this.postService.sendpostImageUrl(postId);
        },
      }); */
  }

  toggleMoodDropdown() {
    this.isMoodOpen = !this.isMoodOpen;
  }

  previewImages: any[] = [];
  getImages(data: any) {
    if (data) {
      this.preview.postImages = data;
      this.previewImages = data;
    }
  }

  ngOnInit(): void {
    this.form.valueChanges.subscribe((x: any) => {
      this.preview = {
        id: this.postId,
        title: x.title as any,
        content: x.content ?? '',
        userId: this.user.id,
        user: this.user,
        postImages: this.previewImages,
      };
      this.hashtags = linkify
        .find(x.content, 'hashtag')
        .map((link) => link.value);
      this.mentions = linkify
        .find(x.content, 'mention')
        .map((link) => link.value);
      this.tickets = linkify
        .find(x.content, 'ticket')
        .map((link) => link.value);
      this.ips = linkify.find(x.content, 'ip').map((link) => link.value);
      this.keywords = linkify
        .find(x.content, 'keyword')
        .map((link) => link.value);

      //make values unique and remove the @ from mentions
      this.mentions = uniq(
        this.mentions.map((mention) => mention.replace('@', ''))
      );

      this.hashtags = uniq(this.hashtags);
    });
  }

  toggleTabs($tabNumber: number) {
    this.openTab = $tabNumber;
  }

  changeTabStyle(tab: number) {
    if (this.openTab !== tab) {
      return 'text-gray-500  px-3 py-1.5 border border-transparent text-sm font-medium rounded-md hover:text-gray-900 bg-white hover:bg-gray-100';
    }
    return 'text-gray-900  bg-gray-100 px-3 py-1.5 border border-transparent text-sm font-medium rounded-md';
  }
  @ViewChild(QuillEditorComponent, { static: true })
  editor!: QuillEditorComponent;
  algoliaClient = algoliasearch(environment.ApplicationId, environment.APIKey);
  algoliaIndex = this.algoliaClient.initIndex('user');

  searchAlgolia(searchTerm: string): Promise<any> {
    return this.algoliaIndex.search(searchTerm);
  }

  analyzeText() {}

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

  openTagPopUp() {
    this.postService.openTagPopup();
  }
  closeTagPopUp() {
    this.postService.CloseTagPopup();
  }
  openCategoryPopUp() {
    this.postService.openCategoryPopup();
  }
  closeCategoryPopUp() {
    this.postService.closeCategoryPopup();
  }

  public onFocus(): void {
    this.isFocused = true;
  }

  public onBlur(): void {
    this.ShowContentErrors = false;
    this.ShowTitleErrors = false;
    this.isFocused = false;
  }
  public onTitleFocus(): void {
    this.isTitleFocused = true;
  }

  public onTitleBlur(): void {
    this.isTitleFocused = false;
  }

  public showContentError(): boolean {
    const contentControl = this.form.get('content');

    return contentControl && contentControl.invalid && this.isFocused;
  }
  //show title error
  public showTitleError(): boolean {
    const titleControl = this.form.get('title');

    return titleControl && titleControl.invalid && this.isTitleFocused;
  }

  public get firstContentErrorMessage(): string | null {
    const errors = this.form.get('content')?.errors;
    if (errors?.required) {
      return 'Content is required';
    }
    //max and lin length
    if (errors?.maxlength) {
      return 'Content is too long';
    }
    if (errors?.minlength) {
      return 'Content is too short';
    }
    return null;
  }

  public get firstTitleErrorMessage(): string | null {
    const errors = this.form.get('title')?.errors;
    if (errors?.required) {
      return 'Title is required';
    }
    //max and lin length
    if (errors?.maxlength) {
      return 'Title is too long';
    }
    if (errors?.minlength) {
      return 'Title is too short';
    }
    return null;
  }

  onSelectionChanged = (event: any) => {
    if (event.oldRange == null) {
      this.onFocus();
    }
    if (event.range == null) {
      this.onBlur();
    }
  };
}
