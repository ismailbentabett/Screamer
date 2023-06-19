import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidebarSkeletonComponent } from './sidebar-skeleton.component';

describe('SidebarSkeletonComponent', () => {
  let component: SidebarSkeletonComponent;
  let fixture: ComponentFixture<SidebarSkeletonComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SidebarSkeletonComponent]
    });
    fixture = TestBed.createComponent(SidebarSkeletonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
