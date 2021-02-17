import { Component, OnInit, Input,EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-product',
  styleUrls: ['./product.component.scss'],
  templateUrl: './product.component.html',

})
export class ProductComponent implements OnInit {
 @Input() productName: string;
 @Output() productClicked= new EventEmitter()

  ngOnInit(): void {

  }
  onCLicked(){
   this.productClicked.emit()
  }
}
