import { TestBed } from '@angular/core/testing';

import { CostserviceService } from './costservice.service';

describe('CostserviceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CostserviceService = TestBed.get(CostserviceService);
    expect(service).toBeTruthy();
  });
});
