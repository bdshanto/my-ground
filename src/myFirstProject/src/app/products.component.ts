import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html'
})
export class ProductsComponent implements OnInit {
  productName: string = 'A book';
  isDisable = false;
  products = ['a book', 'a tree'];

  constructor() {
    setTimeout(() => {
      //  this.ProductName = 'A treee';
      this.isDisable = true;

    }, 3000);
  }

  ngOnInit(): void {}

  onAddProduct() {
    this.products.push(this.productName);
  }

  onRemoveProduct(productName: string): void {
    this.products = this.products.filter(p => p !== productName);
  }
}
