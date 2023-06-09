import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Shop } from '../models/shop.model';
import { PaginationResult } from '../models/pagination-result';
import { ResponseResult } from '../models/response';
import { Warehouse } from '../models/warehouse.model';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl: string = environment.baseUrl + 'shops';

  constructor(private http: HttpClient) { }

  getAll(pageNum?: number, pageSize?: number): Observable<ResponseResult<Shop>> {
    if(pageNum === undefined && pageSize === undefined) return this.http.get<ResponseResult<Shop>>(this.baseUrl);
    return this.http.get<ResponseResult<Shop>>(this.baseUrl + '?pageNum=' + pageNum + '&pageSize=' + pageSize);
  }

  get(id: number){
    return this.http.get(this.baseUrl + '/' + id);
  }

  create(payload: Shop): Observable<any>{
    return this.http.post(this.baseUrl, payload);
  }

  update(id: number, payload: Shop): Observable<any>{
    return this.http.put(this.baseUrl + '/' + id, payload);
  }

  delete(id: number): Observable<any>{
    return this.http.delete(this.baseUrl + '/' + id);
  }

  getWarehouse(shopId: number): Observable<ResponseResult<Shop>> {
    return this.http.get<ResponseResult<Shop>>(this.baseUrl + '/' + shopId + '/warehouse');
  }

  getOrderForAdmin(pageNum?: number, pageSize?: number): Observable<ResponseResult<any>> {
    return this.http.get<ResponseResult<any>>(environment.baseUrl + 'orders' + '?pageNum=' + pageNum + '&pageSize=' + pageSize)
  }

  getOrderForStores(shopId: number, pageNum?: number, pageSize?: number): Observable<ResponseResult<any>> {
    return this.http.get<ResponseResult<any>>(this.baseUrl + '/' + shopId + '/orders'+  '?pageNum=' + pageNum + '&pageSize=' + pageSize)
  }
}
