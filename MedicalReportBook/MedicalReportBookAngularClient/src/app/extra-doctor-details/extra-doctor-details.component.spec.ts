import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExtraDoctorDetailsComponent } from './extra-doctor-details.component';

describe('ExtraDoctorDetailsComponent', () => {
  let component: ExtraDoctorDetailsComponent;
  let fixture: ComponentFixture<ExtraDoctorDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExtraDoctorDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExtraDoctorDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
