import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  baseUrl: string = environment.baseUrl + 'customers';

  constructor(private http: HttpClient) {}

  get(id: number): Observable<any> {
    return this.http.get(this.baseUrl + '/' + id);
  }
  changeInfo(id: number, payload: any): Observable<any> {
    return this.http.put(this.baseUrl + '/' + id, payload);
  }

  createAddress(id: number, payload: any): Observable<any> {
    return this.http.post(this.baseUrl + '/' + id + '/addresses', payload);
  }

  getOrderHistory(id: string): Observable<any> {
    return this.http.get(this.baseUrl + '/' + id + '/orders');
  }

  customerReceivedOrder(id: number, orderId: number): Observable<any> {
    return this.http.patch(this.baseUrl + '/' + id + '/orders/' + orderId, null);
  }

  getInstallmentProduct(id: number): Observable<any> {
    return this.http.get(this.baseUrl + '/' + id + '/installment/');
  }
}
