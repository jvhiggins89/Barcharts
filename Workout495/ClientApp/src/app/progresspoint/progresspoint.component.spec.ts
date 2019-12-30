import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProgressPointComponent } from './progresspoint.component';

describe('GoalComponent', () => {
  let component: ProgressPointComponent;
  let fixture: ComponentFixture<ProgressPointComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ProgressPointComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProgressPointComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
