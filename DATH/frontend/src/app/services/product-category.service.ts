import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProductCategory } from '../models/product-category.model';
import { ResponseResult } from '../models/response';

@Injectable({
  providedIn: 'root'
})
export class ProductCategoryService {
  baseUrl: string = environment.baseUrl + 'productcategorys';

  constructor(private http: HttpClient) { }

  getAll(pageNum?: number, pageSize?: number): Observable<ResponseResult<ProductCategory>> {
    if (pageNum === undefined && pageSize === undefined) return this.http.get<ResponseResult<ProductCategory>>(this.baseUrl);
    else return this.http.get<ResponseResult<ProductCategory>>(this.baseUrl + '?pageNum=' + pageNum + '&pageSize=' + pageSize);
  }

  get(id: number){
    return this.http.get(this.baseUrl + '/' + id);
  }

  update(id: number, payload: ProductCategory): Observable<any>{
    return this.http.put(this.baseUrl + '/' + id, payload);
  }

  create(payload: ProductCategory): Observable<any>{
    return this.http.post(this.baseUrl, payload);
  }

  delete(id: number): Observable<any>{
    return this.http.delete(this.baseUrl + '/' + id);
  }
}
