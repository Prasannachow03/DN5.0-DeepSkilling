import { TestBed } from '@angular/core/testing';
import { AuthService } from './auth';

describe('AuthService', () => {
  it('should be created', () => {
    TestBed.configureTestingModule({});
    const service = TestBed.inject(AuthService);
    expect(service).toBeTruthy();
  });
});