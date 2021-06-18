import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DregisterComponent } from './dregister.component';

describe('DregisterComponent', () => {
  let component: DregisterComponent;
  let fixture: ComponentFixture<DregisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DregisterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DregisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
