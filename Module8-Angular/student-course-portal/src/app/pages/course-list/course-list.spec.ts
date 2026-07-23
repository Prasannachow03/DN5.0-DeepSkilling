import { TestBed } from '@angular/core/testing';
import { CourseListComponent } from './course-list';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { provideStore } from '@ngrx/store';
import { courseReducer } from '../../store/course/course.reducer';

describe('CourseListComponent', () => {
  it('should create', async () => {
    await TestBed.configureTestingModule({
      imports: [CourseListComponent],
      providers: [
        provideRouter([]),
        provideHttpClient(),
        provideStore({ course: courseReducer })
      ]
    }).compileComponents();
    const fixture = TestBed.createComponent(CourseListComponent);
    expect(fixture.componentInstance).toBeTruthy();
  });
});