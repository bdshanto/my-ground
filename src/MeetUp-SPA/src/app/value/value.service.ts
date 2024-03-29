import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ValueService {

  constructor(private _http: HttpClient) {
  }

  getValue(): any {
    return this._http.get('https://localhost:44322/api/values');
  }
}
