import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PtestReportComponent } from './ptest-report.component';

describe('PtestReportComponent', () => {
  let component: PtestReportComponent;
  let fixture: ComponentFixture<PtestReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PtestReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PtestReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
