import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExtraUserDetailsComponent } from './extra-user-details.component';

describe('ExtraUserDetailsComponent', () => {
  let component: ExtraUserDetailsComponent;
  let fixture: ComponentFixture<ExtraUserDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExtraUserDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExtraUserDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
