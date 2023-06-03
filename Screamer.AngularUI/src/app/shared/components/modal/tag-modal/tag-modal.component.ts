import { Component } from '@angular/core';
import algoliasearch from 'algoliasearch';
import { PostService } from 'src/app/core/services/post.service';
import { SearchService } from 'src/app/core/services/search.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-tag-modal',
  templateUrl: './tag-modal.component.html',
  styleUrls: ['./tag-modal.component.scss'],
})
export class TagModalComponent {
  algoliaClient = algoliasearch(environment.ApplicationId, environment.APIKey);
  algoliaIndex = this.algoliaClient.initIndex('user');
  searchAlgolia() {
    const index = this.algoliaClient.initIndex('user');
    if (
      this.postService.tagSearchQuery != '' &&
      this.postService.tagSearchQuery != ' '
    ){
      index.search(this.postService.tagSearchQuery).then((response) => {
        this.postService.tagSearchResults = response.hits.filter(
          (item: any) =>
            !this.postService.tagSearchResultArray.includes(item.userName)
        );
      });
    }else {
      this.postService.tagSearchResults = []
    }

  }

  addTotagSearchResultArray(user: any) {
    this.postService.tagSearchResultArray.push(user);
    this.postService.tagSearchResults =
      this.postService.tagSearchResults.filter(
        (item: any) => item.userName !== user.userName
      );
  }
  removeFromtagSearchResultArray(user: any) {
    this.postService.tagSearchResultArray =
      this.postService.tagSearchResultArray.filter(
        (item: any) => item.userName !== user.userName
      );
    this.postService.tagSearchResults.push(user);
  }

  constructor(public postService: PostService) {}

  openPopup() {
    this.postService.openTagPopup();
  }

  closePopup() {
    this.postService.CloseTagPopup();
  }
}
