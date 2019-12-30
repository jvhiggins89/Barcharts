import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkoutmodalComponent } from './workoutmodal.component';

describe('WorkoutmodalComponent', () => {
  let component: WorkoutmodalComponent;
  let fixture: ComponentFixture<WorkoutmodalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkoutmodalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkoutmodalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
