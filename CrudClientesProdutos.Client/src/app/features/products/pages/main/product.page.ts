import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../../../products.service'
import { Product } from '../../models/product.type';

@Component({
  selector: 'app-product-page',
  standalone: true,
  templateUrl: './product.page.html',
  styleUrl: './product.page.css'
})
export class ProductPage implements OnInit {
  constructor(private _productService : ProductsService) { }
  
  products : Product[] = []

  ngOnInit(): void {
    this._productService.getProducts().subscribe({
      next: (value : any) => this.products = value,
      error: console.log
    })
  }
}
