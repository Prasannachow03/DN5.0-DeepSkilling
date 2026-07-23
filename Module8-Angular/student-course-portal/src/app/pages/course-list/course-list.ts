import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { CourseCardComponent } from '../../components/course-card/course-card';
import { Course } from '../../models/course.model';
import { loadCourses, enrollCourse, unenrollCourse } from '../../store/course/course.actions';
import { selectAllCourses, selectCoursesLoading, selectCoursesError, selectEnrolledIds } from '../../store/course/course.selectors';

@Component({
  selector: 'app-course-list',
  imports: [CommonModule, CourseCardComponent],
  template: `
    <div style="padding:30px;">
      <h1>Course List</h1>
      <p *ngIf="loading$ | async">Loading courses...</p>
      <p *ngIf="error$ | async as error" style="color:red;">{{ error }}</p>
      <ng-container *ngIf="!(loading$ | async)">
        <p>Total: {{ (courses$ | async)?.length }} courses</p>
        <app-course-card
          *ngFor="let course of courses$ | async; trackBy: trackByCourseId"
          [course]="course"
          [isEnrolled]="((enrolledIds$ | async) || []).includes(course.id)"
          (enrollRequested)="onEnroll($event)"
          (click)="viewDetail(course.id)">
        </app-course-card>
      </ng-container>
    </div>
  `
})
export class CourseListComponent implements OnInit {
  courses$: Observable<Course[]>;
  loading$: Observable<boolean>;
  error$: Observable<string | null>;
  enrolledIds$: Observable<number[]>;

  constructor(private store: Store, private router: Router) {
    this.courses$    = this.store.select(selectAllCourses);
    this.loading$    = this.store.select(selectCoursesLoading);
    this.error$      = this.store.select(selectCoursesError);
    this.enrolledIds$ = this.store.select(selectEnrolledIds);
  }

  ngOnInit(): void {
    this.store.dispatch(loadCourses());
  }

  trackByCourseId(index: number, course: Course): number { return course.id; }

  onEnroll(courseId: number): void {
    this.enrolledIds$.subscribe(ids => {
      if (ids.includes(courseId)) {
        this.store.dispatch(unenrollCourse({ courseId }));
      } else {
        this.store.dispatch(enrollCourse({ courseId }));
      }
    }).unsubscribe();
  }

  viewDetail(id: number): void {
    this.router.navigate(['/courses', id]);
  }
}