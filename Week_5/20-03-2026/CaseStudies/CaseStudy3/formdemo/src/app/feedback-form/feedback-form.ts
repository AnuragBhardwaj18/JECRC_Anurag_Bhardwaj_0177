import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-feedback-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './feedback-form.html',
  styleUrl: './feedback-form.css',
})
export class FeedbackForm {

  // Dropdown options
  departments = ['HR', 'Development', 'Design', 'QA'];

  // Ratings
  ratings = [1, 2, 3, 4, 5];

  // Skills Checkbox
  allSkills = ['Angular', 'React', 'Node', 'Python'];

  // Model
  feedback = {
    name: '',
    email: '',
    department: '',
    rating: '',
    comments: '',
    skills: [] as string[]
  };

  // Submit handler
  submitForm(form: NgForm) {
    if (form.valid) {
      console.log('Feedback Submitted', this.feedback);
      alert(JSON.stringify(this.feedback, null, 2));
      form.resetForm();
      this.feedback.skills = [];
    } else {
      alert('Please fill all required fields');
    }
  }

  // Update skills
  updateSkills(skill: string, isChecked: boolean) {
    if (isChecked) {
      this.feedback.skills.push(skill);
    } else {
      const index = this.feedback.skills.indexOf(skill);
      if (index >= 0) this.feedback.skills.splice(index, 1);
    }
  }
}