import { TestBed } from '@angular/core/testing';

import { DoctorApiService } from './doctor-api.service';

describe('DoctorApiService', () => {
  let service: DoctorApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DoctorApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
