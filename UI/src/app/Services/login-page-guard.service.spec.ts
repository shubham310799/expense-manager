import { TestBed } from '@angular/core/testing';

import { LoginPageGuardService } from './login-page-guard.service';

describe('LoginPageGuardService', () => {
  let service: LoginPageGuardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoginPageGuardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
