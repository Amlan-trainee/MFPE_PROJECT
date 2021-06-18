import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorConsultancyreportComponent } from './doctor-consultancyreport.component';

describe('DoctorConsultancyreportComponent', () => {
  let component: DoctorConsultancyreportComponent;
  let fixture: ComponentFixture<DoctorConsultancyreportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoctorConsultancyreportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoctorConsultancyreportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
