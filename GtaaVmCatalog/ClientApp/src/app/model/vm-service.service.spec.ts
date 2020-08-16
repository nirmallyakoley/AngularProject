import { TestBed } from '@angular/core/testing';

import { VmServiceService } from './vm-service.service';

describe('VmServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VmServiceService = TestBed.get(VmServiceService);
    expect(service).toBeTruthy();
  });
});
