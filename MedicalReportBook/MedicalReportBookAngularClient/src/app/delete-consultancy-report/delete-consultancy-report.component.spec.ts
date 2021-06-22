import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteConsultancyReportComponent } from './delete-consultancy-report.component';

describe('DeleteConsultancyReportComponent', () => {
  let component: DeleteConsultancyReportComponent;
  let fixture: ComponentFixture<DeleteConsultancyReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteConsultancyReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteConsultancyReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
