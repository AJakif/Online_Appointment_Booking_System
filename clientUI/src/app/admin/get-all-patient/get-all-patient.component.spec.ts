import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllPatientComponent } from './get-all-patient.component';

describe('GetAllPatientComponent', () => {
  let component: GetAllPatientComponent;
  let fixture: ComponentFixture<GetAllPatientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetAllPatientComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetAllPatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
