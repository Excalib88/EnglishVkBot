import { AppConfig } from './app.config';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { getRusPaginatorIntl } from './config/rus-paginator-intl';
import { CustomMaterialModule } from './custom-material.module';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MAT_DATE_LOCALE, MatPaginatorIntl } from '@angular/material';
import { TranslateFormComponent } from './components/translate-form/translate-form.component';

export function initializeApp(appConfig: AppConfig) {
  return () => appConfig.load();
}

@NgModule({
  declarations: [AppComponent, TranslateFormComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    CustomMaterialModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  exports: [CustomMaterialModule],
  providers: [
    AppConfig,
    { provide: MAT_DATE_LOCALE, useValue: 'ru-RU' },
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      deps: [AppConfig],
      multi: true
    },
    { provide: MatPaginatorIntl, useValue: getRusPaginatorIntl() },
    { provide: 'LOCALSTORAGE', useFactory: getLocalStorage }
  ],
  bootstrap: [AppComponent],
  entryComponents: [TranslateFormComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {}

export function getLocalStorage() {
  return typeof window !== 'undefined' ? window.localStorage : null;
}
