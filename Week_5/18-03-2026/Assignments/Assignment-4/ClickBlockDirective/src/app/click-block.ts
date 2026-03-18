import { Directive, Input, HostListener } from '@angular/core';

@Directive({
  selector: '[appClickBlock]',
  standalone: true
})
export class ClickBlockDirective {

  @Input() appClickBlock!: boolean;

  @HostListener('click', ['$event'])
  handleClick(event: Event) {
    if (!this.appClickBlock) {
      event.stopImmediatePropagation();
      event.preventDefault();
      alert('Click is blocked!');
    }
  }
}