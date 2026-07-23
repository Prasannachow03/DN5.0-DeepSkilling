import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  imports: [RouterLink],
  template: `
    <nav style="background:#1a237e; padding:15px; display:flex; gap:30px; align-items:center;">
      <span style="color:white; font-size:20px; font-weight:bold;">Student Course Portal</span>
      <a routerLink="/home"    style="color:white; text-decoration:none;">Home</a>
      <a routerLink="/courses" style="color:white; text-decoration:none;">Courses</a>
      <a routerLink="/profile" style="color:white; text-decoration:none;">Profile</a>
      <a routerLink="/enroll"  style="color:white; text-decoration:none;">Enroll</a>
    </nav>
  `
})
export class HeaderComponent {}