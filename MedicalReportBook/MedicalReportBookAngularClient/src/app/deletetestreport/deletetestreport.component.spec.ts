import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletetestreportComponent } from './deletetestreport.component';

describe('DeletetestreportComponent', () => {
  let component: DeletetestreportComponent;
  let fixture: ComponentFixture<DeletetestreportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeletetestreportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeletetestreportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
