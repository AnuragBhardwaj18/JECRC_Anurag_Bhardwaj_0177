import { Directive, Input, OnChanges } from '@angular/core';

@Directive({
  selector: '[appTheme]',
  standalone: true
})
export class ThemeDirective implements OnChanges {

  @Input() appTheme!: string;

  ngOnChanges() {
    const body = document.body;

    if (this.appTheme === 'dark') {
      body.style.backgroundColor = '#222';
      body.style.color = '#fff';
    } else {
      body.style.backgroundColor = '#fff';
      body.style.color = '#000';
    }
  }
}