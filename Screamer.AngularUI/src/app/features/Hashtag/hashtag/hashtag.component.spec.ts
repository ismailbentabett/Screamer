import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HashtagComponent } from './hashtag.component';

describe('HashtagComponent', () => {
  let component: HashtagComponent;
  let fixture: ComponentFixture<HashtagComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HashtagComponent]
    });
    fixture = TestBed.createComponent(HashtagComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
