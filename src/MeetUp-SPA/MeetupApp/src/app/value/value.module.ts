import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ValueComponent } from './components/value/value.component';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [ValueComponent],
  imports: [
    CommonModule,
    HttpClientModule,
  ],
  exports: [
    ValueComponent
  ]
})
export class ValueModule { }
