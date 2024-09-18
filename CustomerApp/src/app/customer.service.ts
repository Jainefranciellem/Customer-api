import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  private apiUrl = 'http://localhost:5028/api/customer';

  constructor(private http: HttpClient) {}


  getCustomers(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

}
