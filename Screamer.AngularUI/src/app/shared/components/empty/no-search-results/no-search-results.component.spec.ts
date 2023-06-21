import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoSearchResultsComponent } from './no-search-results.component';

describe('NoSearchResultsComponent', () => {
  let component: NoSearchResultsComponent;
  let fixture: ComponentFixture<NoSearchResultsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NoSearchResultsComponent]
    });
    fixture = TestBed.createComponent(NoSearchResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
