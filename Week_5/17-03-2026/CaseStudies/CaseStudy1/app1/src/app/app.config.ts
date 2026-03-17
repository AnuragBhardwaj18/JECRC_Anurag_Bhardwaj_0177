import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { Hello } from './hello/hello';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter([
      { path: '', component: Hello } 
    ])
  ]
};