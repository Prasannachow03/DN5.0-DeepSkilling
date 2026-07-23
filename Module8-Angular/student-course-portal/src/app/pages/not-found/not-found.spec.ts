import { TestBed } from '@angular/core/testing';
import { NotFoundComponent } from './not-found';
import { provideRouter } from '@angular/router';

describe('NotFoundComponent', () => {
  it('should create', async () => {
    await TestBed.configureTestingModule({
      imports: [NotFoundComponent],
      providers: [provideRouter([])]
    }).compileComponents();
    const fixture = TestBed.createComponent(NotFoundComponent);
    expect(fixture.componentInstance).toBeTruthy();
  });
});