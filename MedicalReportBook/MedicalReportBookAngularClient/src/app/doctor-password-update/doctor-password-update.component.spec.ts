import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorPasswordUpdateComponent } from './doctor-password-update.component';

describe('DoctorPasswordUpdateComponent', () => {
  let component: DoctorPasswordUpdateComponent;
  let fixture: ComponentFixture<DoctorPasswordUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoctorPasswordUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoctorPasswordUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
