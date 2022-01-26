import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllPendinAppointmentComponent } from './get-all-pendin-appointment.component';

describe('GetAllPendinAppointmentComponent', () => {
  let component: GetAllPendinAppointmentComponent;
  let fixture: ComponentFixture<GetAllPendinAppointmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetAllPendinAppointmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetAllPendinAppointmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
