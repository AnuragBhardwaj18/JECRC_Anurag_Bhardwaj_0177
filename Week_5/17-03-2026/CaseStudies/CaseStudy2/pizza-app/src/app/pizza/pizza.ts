import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-pizza',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './pizza.html',
  styleUrls: ['./pizza.css'],
})
export class Pizza {
  pizzaName: string = '';
  quantity: number = 1;
  address: string = '';
}
