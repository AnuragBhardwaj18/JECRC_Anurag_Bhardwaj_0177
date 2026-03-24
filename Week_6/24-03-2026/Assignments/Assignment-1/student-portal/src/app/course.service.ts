import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  private courses = [
    { id: 1, name: 'Angular', description: 'Learn Angular from scratch' },
    { id: 2, name: 'React', description: 'Learn React basics' },
    { id: 3, name: 'Node.js', description: 'Backend development' }
  ];

  getCourses() {
    return this.courses;
  }

  getCourseById(id: number) {
    return this.courses.find(c => c.id === id);
  }
}