import { Component, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HighlightDirective } from '../../directives/highlight';
import { CreditLabelPipe } from '../../pipes/credit-label-pipe';

@Component({
  selector: 'app-course-card',
  imports: [CommonModule, HighlightDirective, CreditLabelPipe],
  template: `
    <div appHighlight="lightblue"
      [ngStyle]="{'border-left': '5px solid ' + getBorderColor()}"
      style="border:1px solid #ccc; padding:15px; border-radius:8px; margin:10px; cursor:pointer;">

      <div [ngSwitch]="course.gradeStatus" style="float:right;">
        <span *ngSwitchCase="'passed'" style="background:green; color:white; padding:3px 8px; border-radius:4px;">Passed</span>
        <span *ngSwitchCase="'failed'" style="background:red;   color:white; padding:3px 8px; border-radius:4px;">Failed</span>
        <span *ngSwitchDefault         style="background:grey;  color:white; padding:3px 8px; border-radius:4px;">Pending</span>
      </div>

      <h3>{{ course.name }}</h3>
      <p>Code: {{ course.code }}</p>
      <p>Credits: {{ course.credits | creditLabel }}</p>

      <button (click)="toggleDetails()" style="margin-right:10px; padding:5px 10px;">
        {{ isExpanded ? 'Hide Details' : 'Show Details' }}
      </button>

      <button (click)="enrollRequested.emit(course.id)"
        [style.background]="isEnrolled ? '#c62828' : '#1a237e'"
        style="padding:5px 10px; color:white; border:none; border-radius:5px; cursor:pointer;">
        {{ isEnrolled ? 'Unenroll' : 'Enroll' }}
      </button>

      <div *ngIf="isExpanded" style="margin-top:10px; background:#f5f5f5; padding:10px; border-radius:5px;">
        <p>Grade Status: {{ course.gradeStatus }}</p>
        <p>Enrolled: {{ isEnrolled ? 'Yes' : 'No' }}</p>
      </div>
    </div>
  `
})
export class CourseCardComponent implements OnChanges {
  @Input() course: Course = { id: 0, name: '', code: '', credits: 0, gradeStatus: 'pending' };
  @Input() isEnrolled = false;
  @Output() enrollRequested = new EventEmitter<number>();
  isExpanded = false;

  ngOnChanges(changes: SimpleChanges): void {
    console.log('ngOnChanges:', changes['course']?.previousValue, '→', changes['course']?.currentValue);
  }

  toggleDetails(): void { this.isExpanded = !this.isExpanded; }

  getBorderColor(): string {
    if (this.course.gradeStatus === 'passed') return 'green';
    if (this.course.gradeStatus === 'failed') return 'red';
    return 'grey';
  }

  get cardClasses() {
    return { 'card--enrolled': this.isEnrolled, 'card--full': this.course.credits >= 4 };
  }
}

interface Course { id: number; name: string; code: string; credits: number; gradeStatus: string; }