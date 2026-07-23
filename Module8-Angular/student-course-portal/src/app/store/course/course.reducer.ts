import { createReducer, on } from '@ngrx/store';
import { Course } from '../../models/course.model';
import { loadCourses, loadCoursesSuccess, loadCoursesFailure, enrollCourse, unenrollCourse } from './course.actions';

export interface CourseState {
  courses: Course[];
  loading: boolean;
  error: string | null;
  enrolledCourseIds: number[];
}

export const initialState: CourseState = {
  courses: [],
  loading: false,
  error: null,
  enrolledCourseIds: []
};

export const courseReducer = createReducer(
  initialState,
  on(loadCourses, state => ({ ...state, loading: true, error: null })),
  on(loadCoursesSuccess, (state, { courses }) => ({ ...state, courses, loading: false })),
  on(loadCoursesFailure, (state, { error }) => ({ ...state, error, loading: false })),
  on(enrollCourse, (state, { courseId }) => ({
    ...state,
    enrolledCourseIds: [...state.enrolledCourseIds, courseId]
  })),
  on(unenrollCourse, (state, { courseId }) => ({
    ...state,
    enrolledCourseIds: state.enrolledCourseIds.filter(id => id !== courseId)
  }))
);