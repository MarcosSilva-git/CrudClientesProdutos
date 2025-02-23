import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  constructor(private http : HttpClient) { }

  getProducts = () => this.http.get("https://localhost:7163/api/v1/product");
}
