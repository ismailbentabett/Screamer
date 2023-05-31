import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchUserListComponent } from './search-user-list.component';

describe('SearchUserListComponent', () => {
  let component: SearchUserListComponent;
  let fixture: ComponentFixture<SearchUserListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchUserListComponent]
    });
    fixture = TestBed.createComponent(SearchUserListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
