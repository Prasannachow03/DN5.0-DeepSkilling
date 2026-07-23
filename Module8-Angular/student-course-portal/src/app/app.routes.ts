import { Routes } from '@angular/router';
import { authGuard } from './guards/auth-guard';
import { unsavedChangesGuard } from './guards/unsaved-changes-guard';

export const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home',            loadComponent: () => import('./pages/home/home').then(m => m.HomeComponent) },
  { path: 'courses',         loadComponent: () => import('./pages/course-list/course-list').then(m => m.CourseListComponent) },
  { path: 'courses/:id',     loadComponent: () => import('./pages/course-detail/course-detail').then(m => m.CourseDetailComponent) },
  { path: 'enroll',          loadComponent: () => import('./pages/enrollment-form/enrollment-form').then(m => m.EnrollmentForm) },
  { path: 'enroll-reactive', loadComponent: () => import('./pages/reactive-enrollment-form/reactive-enrollment-form').then(m => m.ReactiveEnrollmentForm), canDeactivate: [unsavedChangesGuard] },
  { path: 'profile',         loadComponent: () => import('./pages/student-profile/student-profile').then(m => m.StudentProfileComponent), canActivate: [authGuard] },
  { path: '**',              loadComponent: () => import('./pages/not-found/not-found').then(m => m.NotFoundComponent) }
];