import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseService } from '../course.service';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-course-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './course-detail.html'
})
export class CourseDetailComponent {

  course: any;

  constructor(private route: ActivatedRoute, private service: CourseService) {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.course = this.service.getCourseById(id);
  }
}