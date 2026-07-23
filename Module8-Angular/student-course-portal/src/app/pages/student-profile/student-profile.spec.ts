import { TestBed } from '@angular/core/testing';
import { StudentProfileComponent } from './student-profile';

describe('StudentProfileComponent', () => {
  it('should create', async () => {
    await TestBed.configureTestingModule({
      imports: [StudentProfileComponent]
    }).compileComponents();
    const fixture = TestBed.createComponent(StudentProfileComponent);
    expect(fixture.componentInstance).toBeTruthy();
  });
});