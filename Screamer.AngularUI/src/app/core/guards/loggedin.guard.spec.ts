import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { loggedinGuard } from './loggedin.guard';

describe('loggedinGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => loggedinGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
