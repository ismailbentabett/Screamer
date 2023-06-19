import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidecontentSkeletonComponent } from './sidecontent-skeleton.component';

describe('SidecontentSkeletonComponent', () => {
  let component: SidecontentSkeletonComponent;
  let fixture: ComponentFixture<SidecontentSkeletonComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SidecontentSkeletonComponent]
    });
    fixture = TestBed.createComponent(SidecontentSkeletonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
