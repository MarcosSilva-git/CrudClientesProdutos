import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core'
import { ProductsService } from "./products.service"
import { Product } from "./models/product.model"
import { PagedResponse } from '../../core/models/paged-response.model'
import { CommonModule } from '@angular/common'
import { MatTableDataSource, MatTableModule } from '@angular/material/table'
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';

@Component({
  selector: 'app-product-page',
  imports: [CommonModule, MatTableModule, MatIconModule, MatPaginatorModule],
  standalone: true,
  templateUrl: './product.page.html',
  styleUrl: './product.page.css'
})
export class ProductPage implements OnInit, AfterViewInit {
  products?: PagedResponse<Product>
  displayedColumns: string[] = ['id', 'name', 'price', 'stock', 'actions']
  dataSource = new MatTableDataSource<Product>([])

  @ViewChild(MatPaginator) paginator?: MatPaginator;

  constructor(private _productService : ProductsService) { }

  ngAfterViewInit() {
    this.paginator!.page.subscribe((event : any) => {
      this.getProducts(event.pageIndex, event.pageSize);
    });
  }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(pageIndex: number = 0, pageSize: number = 5): void {
    console.log(pageIndex, pageSize)
    this._productService.getProducts(pageSize, pageIndex).subscribe({
      next: (response: PagedResponse<Product>) => {
        this.products = response

        console.log(this.products)
        if (this.paginator) {
          this.paginator.length = this.products.totalItems
        }
        console.log(this.paginator)
      },
      error: erro => console.error('Erro ao carregar produtos:', erro)
    });
  }

  deleteProduct(product: Product): void {
    if (confirm(`Tem certeza que deseja excluir ${product.name}?`)) {
      console.log('Produto excluído:', product);
    }
  }
}
