import { Component, ViewChild } from '@angular/core';
import algoliasearch from 'algoliasearch';
import { QuillEditorComponent } from 'ngx-quill';
import { take } from 'rxjs';
import { UserService } from 'src/app/core/services/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-comment-input',
  templateUrl: './comment-input.component.html',
  styleUrls: ['./comment-input.component.scss']
})
export class CommentInputComponent {
  @ViewChild(QuillEditorComponent, { static: true })
  editor!: QuillEditorComponent;
  algoliaClient = algoliasearch(environment.ApplicationId, environment.APIKey);
  algoliaIndex = this.algoliaClient.initIndex('user');
  currentUser: any;

  searchAlgolia(searchTerm: string): Promise<any> {
    return this.algoliaIndex.search(searchTerm);
  }
  constructor(
    private userService: UserService,

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

}
