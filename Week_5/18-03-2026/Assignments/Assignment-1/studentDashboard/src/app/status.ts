import { Directive, ElementRef, Input, OnInit } from '@angular/core';

@Directive({
  selector: '[appStatus]',
  standalone: true
})
export class StatusDirective implements OnInit {

  @Input() appStatus!: number;

  constructor(private el: ElementRef) {}

  ngOnInit() {
    if (this.appStatus >= 50) {
      this.el.nativeElement.style.color = 'green';
    } else {
      this.el.nativeElement.style.color = 'red';
    }
  }
}