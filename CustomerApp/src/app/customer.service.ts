import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, ReplaySubject, Subject, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  private apiUrl = 'http://localhost:5028/api/customer';

  constructor(private http: HttpClient) {}


  getCustomers(): Observable<any[]> {
    const cacheBuster = new Date().getTime(); // Adiciona um parâmetro para evitar cache
    return this.http.get<any[]>(`${this.apiUrl}`);
  }
  

  getCustomerById(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  createCustomer(customer: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, customer)
  }

  updateCustomer(id: string, customer: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, customer);
  }

  deleteCustomer(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }

}
