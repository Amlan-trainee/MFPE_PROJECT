import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddtestReportComponent } from './addtest-report.component';

describe('AddtestReportComponent', () => {
  let component: AddtestReportComponent;
  let fixture: ComponentFixture<AddtestReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddtestReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddtestReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
