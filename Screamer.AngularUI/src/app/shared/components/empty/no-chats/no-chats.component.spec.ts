import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoChatsComponent } from './no-chats.component';

describe('NoChatsComponent', () => {
  let component: NoChatsComponent;
  let fixture: ComponentFixture<NoChatsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NoChatsComponent]
    });
    fixture = TestBed.createComponent(NoChatsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
