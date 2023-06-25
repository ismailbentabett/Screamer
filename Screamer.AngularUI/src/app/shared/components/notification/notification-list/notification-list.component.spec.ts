import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotificationListComponent } from './notification-list.component';

describe('NotificationListComponent', () => {
  let component: NotificationListComponent;
  let fixture: ComponentFixture<NotificationListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NotificationListComponent]
    });
    fixture = TestBed.createComponent(NotificationListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
