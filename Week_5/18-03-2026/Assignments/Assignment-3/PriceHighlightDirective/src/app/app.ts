import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PriceDirective } from './price';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, PriceDirective],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  products = [
    { name: 'Laptop', price: 75000 },
    { name: 'Mobile', price: 30000 },
    { name: 'TV', price: 55000 },
    { name: 'Headphones', price: 2000 }
  ];
}