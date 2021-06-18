import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorTestreportComponent } from './doctor-testreport.component';

describe('DoctorTestreportComponent', () => {
  let component: DoctorTestreportComponent;
  let fixture: ComponentFixture<DoctorTestreportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoctorTestreportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoctorTestreportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
