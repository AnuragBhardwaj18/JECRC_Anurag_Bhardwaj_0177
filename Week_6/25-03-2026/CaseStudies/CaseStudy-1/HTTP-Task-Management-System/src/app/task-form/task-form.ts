import { Component, Output, EventEmitter } from '@angular/core';
import { TaskService } from '../task.service';
import { Task } from '../task';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './task-form.html',
  styleUrl: './task-form.css'
})
export class TaskForm {
  task: Task = { title: '', completed: false };

  @Output() taskAdded = new EventEmitter<void>();

  constructor(private taskService: TaskService) {}

  addTask(): void {
    if (this.task.title.trim()) {
      this.taskService.addTask(this.task).subscribe(() => {
        this.task = { title: '', completed: false };
        this.taskAdded.emit();
      });
    }
  }
}