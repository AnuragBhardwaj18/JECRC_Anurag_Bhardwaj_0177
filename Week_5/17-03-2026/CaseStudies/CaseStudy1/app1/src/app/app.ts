import { Component } from '@angular/core';
import { HomeComponent } from './home/home';
import { Users } from './user/user';
import { Product } from './product/product';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HomeComponent, Users, Product],
  template: `
    <h1>My Application</h1>

    <app-home></app-home>
    <app-user></app-user>
    <app-product></app-product>
  `
})
export class App {}