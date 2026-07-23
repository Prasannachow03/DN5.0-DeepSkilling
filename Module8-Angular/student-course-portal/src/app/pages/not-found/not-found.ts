import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-not-found',
  imports: [RouterLink],
  template: `
    <div style="padding:50px; text-align:center;">
      <h1 style="font-size:80px; color:#1a237e;">404</h1>
      <h2>Page Not Found</h2>
      <p>The page you are looking for does not exist.</p>
      <a routerLink="/home" style="color:#1a237e;">Go back to Home</a>
    </div>
  `
})
export class NotFoundComponent {}