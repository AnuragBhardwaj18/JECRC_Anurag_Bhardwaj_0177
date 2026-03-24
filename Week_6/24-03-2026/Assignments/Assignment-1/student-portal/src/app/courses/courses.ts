import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseService } from '../course.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-courses',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './courses.html',
  styleUrl: './courses.css'
})
export class CoursesComponent {

  courses: any[] = [];

  constructor(private service: CourseService, private router: Router) {
    this.courses = this.service.getCourses();
  }

  viewDetails(id: number) {
    this.router.navigate(['/course', id]);
  }
}