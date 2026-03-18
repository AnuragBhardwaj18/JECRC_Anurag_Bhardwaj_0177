import { Directive, ElementRef, Input, OnInit } from '@angular/core';

@Directive({
  selector: '[appPrice]',
  standalone: true
})
export class PriceDirective implements OnInit {

  @Input() appPrice!: number;

  constructor(private el: ElementRef) {}

  ngOnInit() {
    if (this.appPrice > 50000) {
      this.el.nativeElement.style.color = 'red';
      this.el.nativeElement.style.fontWeight = 'bold';
    } else {
      this.el.nativeElement.style.color = 'green';
    }
  }
}