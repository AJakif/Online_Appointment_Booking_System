import { TestBed } from '@angular/core/testing';

import { PatientApiService } from './patient-api.service';

describe('PatientApiService', () => {
  let service: PatientApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PatientApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
