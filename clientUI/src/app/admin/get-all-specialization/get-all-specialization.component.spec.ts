import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllSpecializationComponent } from './get-all-specialization.component';

describe('GetAllSpecializationComponent', () => {
  let component: GetAllSpecializationComponent;
  let fixture: ComponentFixture<GetAllSpecializationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetAllSpecializationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetAllSpecializationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
