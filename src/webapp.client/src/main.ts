/// <reference types="@angular/localize" />

import { BrowserModule, bootstrapApplication } from '@angular/platform-browser';
import { withInterceptorsFromDi, provideHttpClient } from '@angular/common/http';
import { AppRoutingModule } from './app/app-routing.module';
import { AppComponent } from './app/app.component';
import { importProvidersFrom } from '@angular/core';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

bootstrapApplication(AppComponent, {
    providers: [
        importProvidersFrom(BrowserModule, AppRoutingModule),
        provideHttpClient(withInterceptorsFromDi()),
        provideAnimationsAsync()
    ]
})
  .catch(err => console.error(err));
