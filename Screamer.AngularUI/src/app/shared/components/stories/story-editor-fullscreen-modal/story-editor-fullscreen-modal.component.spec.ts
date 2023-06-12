import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryEditorFullscreenModalComponent } from './story-editor-fullscreen-modal.component';

describe('StoryEditorFullscreenModalComponent', () => {
  let component: StoryEditorFullscreenModalComponent;
  let fixture: ComponentFixture<StoryEditorFullscreenModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StoryEditorFullscreenModalComponent]
    });
    fixture = TestBed.createComponent(StoryEditorFullscreenModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
