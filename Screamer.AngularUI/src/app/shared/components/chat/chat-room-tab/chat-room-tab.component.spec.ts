import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChatRoomTabComponent } from './chat-room-tab.component';

describe('ChatRoomTabComponent', () => {
  let component: ChatRoomTabComponent;
  let fixture: ComponentFixture<ChatRoomTabComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ChatRoomTabComponent]
    });
    fixture = TestBed.createComponent(ChatRoomTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
