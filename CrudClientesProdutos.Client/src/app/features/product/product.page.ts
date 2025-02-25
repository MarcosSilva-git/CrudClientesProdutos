import { Component, OnInit } from '@angular/core'
import { ProductsService } from "./products.service"
import { Product } from "./models/product.model"
import { PagedResponse } from '../../core/models/paged-response.model'
import { CommonModule } from '@angular/common'

@Component({
  selector: 'app-product-page',
  imports: [CommonModule],
  standalone: true,
  templateUrl: './product.page.html',
  styleUrl: './product.page.css'
})
export class ProductPage implements OnInit {
  constructor(private _productService : ProductsService) { }
  
  products?: PagedResponse<Product>

  ngOnInit(): void {
    this._productService.getProducts().subscribe({
      next: (value) => this.products = value,
      error: erro => console.log(erro)
    })
  }
}
