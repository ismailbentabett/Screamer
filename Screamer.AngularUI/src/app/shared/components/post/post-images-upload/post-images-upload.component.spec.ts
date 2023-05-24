import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostImagesUploadComponent } from './post-images-upload.component';

describe('PostImagesUploadComponent', () => {
  let component: PostImagesUploadComponent;
  let fixture: ComponentFixture<PostImagesUploadComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PostImagesUploadComponent]
    });
    fixture = TestBed.createComponent(PostImagesUploadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
