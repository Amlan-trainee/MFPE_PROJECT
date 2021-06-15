import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddpconsultancyReportComponent } from './addpconsultancy-report.component';

describe('AddpconsultancyReportComponent', () => {
  let component: AddpconsultancyReportComponent;
  let fixture: ComponentFixture<AddpconsultancyReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddpconsultancyReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddpconsultancyReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
