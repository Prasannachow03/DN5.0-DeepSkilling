import { TestBed } from '@angular/core/testing';
import { HeaderComponent } from './header';
import { provideRouter } from '@angular/router';

describe('HeaderComponent', () => {
  it('should create', async () => {
    await TestBed.configureTestingModule({
      imports: [HeaderComponent],
      providers: [provideRouter([])]
    }).compileComponents();
    const fixture = TestBed.createComponent(HeaderComponent);
    expect(fixture.componentInstance).toBeTruthy();
  });
});