import { Injectable } from '@angular/core';
import { Course } from '../models/course.model';

@Injectable({ providedIn: 'root' })
export class EnrollmentService {
  private enrolledCourseIds: number[] = [];
  private courseCache: Course[] = [];

  setCourses(courses: Course[]): void {
    this.courseCache = courses;
  }

  enroll(courseId: number): void {
    if (!this.isEnrolled(courseId))
      this.enrolledCourseIds.push(courseId);
  }

  unenroll(courseId: number): void {
    this.enrolledCourseIds = this.enrolledCourseIds.filter(id => id !== courseId);
  }

  isEnrolled(courseId: number): boolean {
    return this.enrolledCourseIds.includes(courseId);
  }

  getEnrolledCourses(): Course[] {
    return this.courseCache.filter(c => this.enrolledCourseIds.includes(c.id));
  }
}