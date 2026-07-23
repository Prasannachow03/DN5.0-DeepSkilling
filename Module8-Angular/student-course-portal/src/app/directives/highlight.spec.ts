import { TestBed } from '@angular/core/testing';
import { HighlightDirective } from './highlight';
import { Component } from '@angular/core';

@Component({ template: `<div appHighlight></div>`, imports: [HighlightDirective] })
class TestComponent {}

describe('HighlightDirective', () => {
  it('should create', async () => {
    await TestBed.configureTestingModule({ imports: [TestComponent] }).compileComponents();
    const fixture = TestBed.createComponent(TestComponent);
    expect(fixture).toBeTruthy();
  });
});