import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HighlightDirective } from './highlight';
import { StatusDirective } from './status';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, HighlightDirective, StatusDirective],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  students = [
    { name: 'Anurag', marks: 92 },
    { name: 'Rahul', marks: 45 },
    { name: 'Priya', marks: 76 },
    { name: 'Sneha', marks: 88 },
    { name: 'Amit', marks: 33 }
  ];

  getGrade(marks: number) {
    if (marks >= 90) return 'A';
    else if (marks >= 75) return 'B';
    else if (marks >= 50) return 'C';
    else return 'F';
  }
}