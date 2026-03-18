import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatusColorDirective } from './status-color';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, StatusColorDirective],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  students = [
    { name: 'Anurag', marks: 85 },
    { name: 'Rahul', marks: 40 },
    { name: 'Priya', marks: 72 },
    { name: 'Amit', marks: 30 }
  ];
}