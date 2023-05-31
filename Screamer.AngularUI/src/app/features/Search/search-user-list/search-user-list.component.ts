import { Component } from '@angular/core';
import { Router } from '@angular/router';
import {
  concat,
  find,
  findIndex,
  head,
  isEqual,
  merge,
  mergeWith,
  reduce,
  result,
} from 'lodash';
import { SearchService } from 'src/app/core/services/search.service';

@Component({
  selector: 'app-search-user-list',
  templateUrl: './search-user-list.component.html',
  styleUrls: ['./search-user-list.component.scss'],
})
export class SearchUserListComponent {
  hasMoreResults: boolean = true;
  mergedArray!: any;
  constructor(public searchService: SearchService ,
    private router: Router
    ) {}
  loadMore() {
    if (this.searchService.searchQuery == '') return;
    this.searchService.getPaginatedResults().then((response) => {
      const results = response.results.map((result) => result.hits).flat();
      if (results.length === 0) {
        this.hasMoreResults = false;
        return;
      }
      console.log(results);

      let data: any = {};
      response.results.forEach((result: any) => {
        data[result.index] = result.hits;
      });
      const arrayOfObjects: any = Object.entries(data).map(([key, value]) => ({
        key,
        value,
      }));

      this.searchService.searchResults
        .asObservable()
        .subscribe((searchResults: any) => {
          let merged: any = {};

          // Merge existing search results
          searchResults.forEach((obj: { key: string; value: any[] }) => {
            if (merged[obj.key]) {
              merged[obj.key] = merged[obj.key].concat(obj.value);
            } else {
              merged[obj.key] = obj.value;
            }
          });

          // Merge new results from the response
          response.results.forEach((result: any) => {
            if (merged[result.index]) {
              merged[result.index] = merged[result.index].concat(result.hits);
            } else {
              merged[result.index] = result.hits;
            }
          });

          // Create the merged array
          this.mergedArray = Object.entries(merged).map(([key, value]) => ({
            key,
            value,
          }));
        });
      this.searchService.searchResults.next(this.mergedArray);
    });
  }

  getUsertData(searchResults: any) {
    //five me the object with the key post
    let postObject = find(
      searchResults,
      (obj: { key: string; value: any[] }) => {
        return obj.key === 'user';
      }
    );
    console.log(postObject);
    return postObject;
  }

  getObjectKey(object: any, index: any) {
    console.log(object, ' ', index);
    return Object.keys(object)[index];
  }

  getFirstImage(array: any) {
    let data: any = head(JSON.parse(array as any));
    if (data) {
      return data!.url;
    }
    return false;
  }

  routeToUser(id: any) {
    this.router.navigate(['/v/user', id]);
    this.searchService.searchQuery = ''
    this.searchService.closePopup()
  }
}
