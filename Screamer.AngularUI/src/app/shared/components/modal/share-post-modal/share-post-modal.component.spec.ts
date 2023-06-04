import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SharePostModalComponent } from './share-post-modal.component';

describe('SharePostModalComponent', () => {
  let component: SharePostModalComponent;
  let fixture: ComponentFixture<SharePostModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SharePostModalComponent]
    });
    fixture = TestBed.createComponent(SharePostModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
