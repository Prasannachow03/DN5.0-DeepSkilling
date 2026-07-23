import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [FormsModule, CommonModule],
  template: `
    <div style="padding:30px;">
      <!-- Interpolation -->
      <h1>{{ portalName }}</h1>
      <p>Manage your courses, enrollments and grades all in one place.</p>

      <!-- Stats -->
      <div style="display:flex; gap:30px; margin-top:20px;">
        <div style="background:#e3f2fd; padding:20px; border-radius:8px; text-align:center;">
          <h2>{{ coursesCount }}</h2><p>Courses Available</p>
        </div>
        <div style="background:#e8f5e9; padding:20px; border-radius:8px; text-align:center;">
          <h2>3</h2><p>Enrolled</p>
        </div>
        <div style="background:#fff3e0; padding:20px; border-radius:8px; text-align:center;">
          <h2>3.8</h2><p>GPA</p>
        </div>
      </div>

      <!-- Property Binding + Event Binding -->
      <div style="margin-top:30px;">
        <button
          [disabled]="!isPortalActive"
          (click)="onEnrollClick()"
          style="padding:10px 20px; background:#1a237e; color:white; border:none; border-radius:5px; cursor:pointer;">
          Enroll Now
        </button>
        <p *ngIf="message" style="color:green; margin-top:10px;">{{ message }}</p>
      </div>

      <!-- Two-way Binding -->
      <div style="margin-top:20px;">
        <input
          [(ngModel)]="searchTerm"
          placeholder="Search courses..."
          style="padding:8px; width:300px; border:1px solid #ccc; border-radius:5px;" />
        <!-- [property] is one-way: component → DOM -->
        <!-- [(ngModel)] is two-way: DOM ↔ component -->
        <p>Searching for: <strong>{{ searchTerm }}</strong></p>
      </div>
    </div>
  `
})
export class HomeComponent implements OnInit, OnDestroy {
  portalName = 'Welcome to Student Course Portal';
  isPortalActive = true;
  message = '';
  searchTerm = '';
  coursesCount = 0;

  ngOnInit(): void {
    // Simulate fetching courses count
    this.coursesCount = 12;
    console.log('HomeComponent initialised — courses loaded');
  }

  ngOnDestroy(): void {
    console.log('HomeComponent destroyed');
  }

  onEnrollClick(): void {
    this.message = 'Enrollment opened!';
  }
}