import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToggleTestStatusComponent } from './toggle-test-status.component';

describe('ToggleTestStatusComponent', () => {
  let component: ToggleTestStatusComponent;
  let fixture: ComponentFixture<ToggleTestStatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToggleTestStatusComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToggleTestStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
