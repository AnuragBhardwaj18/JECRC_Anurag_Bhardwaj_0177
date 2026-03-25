import { Component } from '@angular/core';
import { CartService } from '../cart.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product',
  imports: [CommonModule],
  templateUrl: './product.html',
  styleUrl: './product.css',
  providers: [CartService]
})
export class Product {
  products = [
    {id: 1, name: 'Laptop', price: 999},
    {id: 2, name: 'Smartphone', price: 499},
    {id: 3, name: 'Headphone', price: 199}
  ];
  constructor(private cartService: CartService){}

  addToCart(product: any){
    this.cartService.addToCart(product.name);
  }
  getItems(){
    return this.cartService.getItems();
  }
}
