import { TestBed } from '@angular/core/testing';

import { SecretaryApiService } from './secretary-api.service';

describe('SecretaryApiService', () => {
  let service: SecretaryApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SecretaryApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
