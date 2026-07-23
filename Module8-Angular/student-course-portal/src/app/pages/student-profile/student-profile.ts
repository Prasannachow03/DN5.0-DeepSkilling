import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EnrollmentService } from '../../services/enrollment';
import { Course } from '../../models/course.model';

@Component({
  selector: 'app-student-profile',
  imports: [CommonModule],
  template: `
    <div style="padding:30px;">
      <h1>Student Profile</h1>
      <p>Name: Lakshmi Prasanna</p>
      <p>GPA: 3.8</p>
      <h2>Enrolled Courses ({{ enrolledCourses.length }})</h2>
      <div *ngIf="enrolledCourses.length === 0">
        <p>No courses enrolled yet. Go to Courses page to enroll!</p>
      </div>
      <div *ngFor="let course of enrolledCourses"
        style="border:1px solid #ccc; padding:10px; margin:10px 0; border-radius:5px; border-left:4px solid green;">
        <h3>{{ course.name }}</h3>
        <p>Code: {{ course.code }} | Credits: {{ course.credits }}</p>
      </div>
    </div>
  `
})
export class StudentProfileComponent implements OnInit {
  enrolledCourses: Course[] = [];

  constructor(private enrollmentService: EnrollmentService) {}

  ngOnInit(): void {
    this.enrolledCourses = this.enrollmentService.getEnrolledCourses();
  }
}