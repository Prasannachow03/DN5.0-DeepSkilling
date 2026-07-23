import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CourseCardComponent } from './course-card';
import { By } from '@angular/platform-browser';
import { SimpleChange } from '@angular/core';
import { vi } from 'vitest';

describe('CourseCardComponent', () => {
  let component: CourseCardComponent;
  let fixture: ComponentFixture<CourseCardComponent>;

  const mockCourse = {
    id: 1, name: 'Data Structures', code: 'CS101', credits: 4, gradeStatus: 'passed'
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseCardComponent]
    }).compileComponents();
    fixture = TestBed.createComponent(CourseCardComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should display course name', () => {
    component.course = mockCourse;
    fixture.detectChanges();
    const h3 = fixture.debugElement.query(By.css('h3'));
    expect(h3.nativeElement.textContent).toContain('Data Structures');
  });

  it('should emit enrollRequested on enroll button click', () => {
    component.course = mockCourse;
    fixture.detectChanges();
    const spy = vi.spyOn(component.enrollRequested, 'emit');
    const buttons = fixture.debugElement.queryAll(By.css('button'));
    buttons[buttons.length - 1].nativeElement.click();
    fixture.detectChanges();
    expect(spy).toHaveBeenCalledWith(1);
  });

  it('should toggle isExpanded on Show Details click', () => {
    component.course = mockCourse;
    fixture.detectChanges();
    expect(component.isExpanded).toBeFalsy();
    const btn = fixture.debugElement.query(By.css('button'));
    btn.nativeElement.click();
    fixture.detectChanges();
    expect(component.isExpanded).toBeTruthy();
  });

  it('should call console.log on ngOnChanges', () => {
    const spy = vi.spyOn(console, 'log');
    component.ngOnChanges({
      course: new SimpleChange(null, mockCourse, true)
    });
    expect(spy).toHaveBeenCalled();
  });
});