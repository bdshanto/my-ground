import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html'
})
export class ProductsComponent implements OnInit {
  ProductName: string = 'A book';

  constructor() {
    setTimeout(()=>{
      this.ProductName= 'A treee';
    },3000);
  }

  ngOnInit(): void {}

}
