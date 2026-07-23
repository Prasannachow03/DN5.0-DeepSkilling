import { TestBed } from '@angular/core/testing';
import { CourseDetailComponent } from './course-detail';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';

describe('CourseDetailComponent', () => {
  it('should create', async () => {
    await TestBed.configureTestingModule({
      imports: [CourseDetailComponent],
      providers: [provideRouter([]), provideHttpClient()]
    }).compileComponents();
    const fixture = TestBed.createComponent(CourseDetailComponent);
    expect(fixture.componentInstance).toBeTruthy();
  });
});