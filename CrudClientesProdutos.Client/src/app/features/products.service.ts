import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from './products/models/product.type';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  conrecord structor(private http : HttpClient) { }

  getProducts() : Observable<Product[]> {
    return this.http.get<Product[]>("https://localhost:7163/api/v1/product");
  } 
}
