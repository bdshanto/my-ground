import {Component, OnInit} from '@angular/core';
import {ValueService} from '../../value.service';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  values: any;

  constructor(private _valueService: ValueService) {
  }

  ngOnInit(): void {
    this.getValue();
  }

  getValue(): any {
    this._valueService.getValue().subscribe((rData: any) => {
      this.values = rData;
    }, (error: Error) => {
      console.log(error);
    });
  }

}
