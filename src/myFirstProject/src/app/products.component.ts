import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html'
})
export class ProductsComponent implements OnInit {
  ProductName: string = 'A book';
  isDisable = true;

  constructor() {
    setTimeout(() => {
      //  this.ProductName = 'A treee';
      this.isDisable = false;

    }, 3000);
  }

  ngOnInit(): void {}

}
