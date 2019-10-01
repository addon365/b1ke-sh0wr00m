import { TestBed } from '@angular/core/testing';

import { CampaingService } from './campaing.service';

describe('CampaingService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CampaingService = TestBed.get(CampaingService);
    expect(service).toBeTruthy();
  });
});
