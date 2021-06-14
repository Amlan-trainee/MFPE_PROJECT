import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PconsultancyReportComponent } from './pconsultancy-report.component';

describe('PconsultancyReportComponent', () => {
  let component: PconsultancyReportComponent;
  let fixture: ComponentFixture<PconsultancyReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PconsultancyReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PconsultancyReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
