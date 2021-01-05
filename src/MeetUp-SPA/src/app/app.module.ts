import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {ValueModule} from './value/value.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    ValueModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
