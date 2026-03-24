import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RxjsDemoComponent } from './rxjs-demo/rxjs-demo';

@Component({
  selector: 'app-root',
  imports: [RxjsDemoComponent],
  template: `<app-rxjs-demo></app-rxjs-demo>`,
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('rxjs-demo');
}
