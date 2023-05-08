import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyComponenetComponent } from './my-componenet.component';

describe('MyComponenetComponent', () => {
  let component: MyComponenetComponent;
  let fixture: ComponentFixture<MyComponenetComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MyComponenetComponent]
    });
    fixture = TestBed.createComponent(MyComponenetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
