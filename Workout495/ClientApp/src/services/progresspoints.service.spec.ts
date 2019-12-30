import { TestBed } from '@angular/core/testing';

import { ProgressPointsService } from './progresspoints.service';

describe('ProgressPointsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
      const service: ProgressPointsService = TestBed.get(ProgressPointsService);
    expect(service).toBeTruthy();
  });
});
