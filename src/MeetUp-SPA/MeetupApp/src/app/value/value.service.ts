import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ValueService {

  constructor(private http: HttpClient) {
  }

  getValue(): any {
    return this.http.get('http://localhost:44890/api/values');
  }
}
