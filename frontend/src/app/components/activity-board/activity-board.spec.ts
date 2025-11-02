import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivityBoard } from './activity-board';

describe('ActivityBoard', () => {
  let component: ActivityBoard;
  let fixture: ComponentFixture<ActivityBoard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ActivityBoard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ActivityBoard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
