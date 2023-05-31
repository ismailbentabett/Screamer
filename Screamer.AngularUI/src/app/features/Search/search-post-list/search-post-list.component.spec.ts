import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchPostListComponent } from './search-post-list.component';

describe('SearchPostListComponent', () => {
  let component: SearchPostListComponent;
  let fixture: ComponentFixture<SearchPostListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchPostListComponent]
    });
    fixture = TestBed.createComponent(SearchPostListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
