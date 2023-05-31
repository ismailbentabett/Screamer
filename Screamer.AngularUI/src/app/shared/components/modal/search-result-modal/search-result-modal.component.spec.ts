import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchResultModalComponent } from './search-result-modal.component';

describe('SearchResultModalComponent', () => {
  let component: SearchResultModalComponent;
  let fixture: ComponentFixture<SearchResultModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchResultModalComponent]
    });
    fixture = TestBed.createComponent(SearchResultModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
