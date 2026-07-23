import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CourseService } from '../../services/course';
import { Course } from '../../models/course.model';

@Component({
  selector: 'app-course-detail',
  imports: [CommonModule],
  template: `
    <div style="padding:30px;">
      <button (click)="router.navigate(['/courses'])"
        style="margin-bottom:20px; padding:8px 15px; cursor:pointer;">
        ← Back
      </button>
      <p *ngIf="isLoading">Loading...</p>
      <p *ngIf="errorMessage" style="color:red;">{{ errorMessage }}</p>
      <div *ngIf="course && !isLoading">
        <h1>{{ course.name }}</h1>
        <p>Code: {{ course.code }}</p>
        <p>Credits: {{ course.credits }}</p>
        <p>Grade Status: {{ course.gradeStatus }}</p>
      </div>
    </div>
  `
})
export class CourseDetailComponent implements OnInit {
  course: Course | undefined;
  isLoading = true;
  errorMessage = '';

  constructor(
    private route: ActivatedRoute,
    public router: Router,
    private courseService: CourseService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.courseService.getCourseById(id).subscribe({
      next: course => { this.course = course; this.isLoading = false; },
      error: err => { this.errorMessage = err.message; this.isLoading = false; }
    });
  }
}