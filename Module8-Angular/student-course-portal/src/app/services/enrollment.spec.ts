import { TestBed } from '@angular/core/testing';
import { EnrollmentService } from './enrollment';
import { provideHttpClient } from '@angular/common/http';

describe('EnrollmentService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EnrollmentService, provideHttpClient()]
    });
  });

  it('should be created', () => {
    const service = TestBed.inject(EnrollmentService);
    expect(service).toBeTruthy();
  });
});