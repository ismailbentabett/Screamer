import { TestBed } from '@angular/core/testing';

import { CorService } from './cor.service';

describe('CorService', () => {
  let service: CorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
