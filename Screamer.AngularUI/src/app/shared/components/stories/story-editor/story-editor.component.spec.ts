import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryEditorComponent } from './story-editor.component';

describe('StoryEditorComponent', () => {
  let component: StoryEditorComponent;
  let fixture: ComponentFixture<StoryEditorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StoryEditorComponent]
    });
    fixture = TestBed.createComponent(StoryEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
