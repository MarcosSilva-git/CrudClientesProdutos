import { Component, OnInit, ViewChild, AfterViewInit, inject } from '@angular/core'
import { ProductsService } from "./products.service"
import { Product } from "./models/product.model"
import { PagedResponse } from '../../core/models/paged-response.model'
import { CommonModule } from '@angular/common'
import { MatTableDataSource, MatTableModule } from '@angular/material/table'
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { ProductCreateUpdateDialogComponent, ProductCreateUpdateDialogData } from './components/product-create-update-dialog/product-create-update-dialog.component'
import { MatButtonModule } from '@angular/material/button'

@Component({
  selector: 'app-product-page',
  imports: [CommonModule, MatTableModule, MatIconModule, MatPaginatorModule, MatButtonModule ],
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

  readonly dialog = inject(MatDialog);

  openDialog(product?: Product): void {
    const dialogRef = this.dialog.open<ProductCreateUpdateDialogComponent, ProductCreateUpdateDialogData>(
      ProductCreateUpdateDialogComponent, {
      data: {
        product: product,
        title: product ? 'Editar Produto' : 'Criar Produto' 
      },
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getProducts(this.paginator!.pageIndex, this.paginator!.pageSize)
      }
    });
  }

  ngAfterViewInit() {
    this.paginator!.page.subscribe((event : any) => {
      this.getProducts(event.pageIndex, event.pageSize);
    });
  }

  ngOnInit(): void {
    this.getProducts();
  }

  updateTable() {
    this.dataSource.data = this.products!.items

    if (this.paginator) {
      this.paginator.length = this.products!.totalItems
    }
  }

  getProducts(pageIndex: number = 0, pageSize: number = 5): void {
    this._productService.get(pageSize, pageIndex).subscribe({
      next: (response: PagedResponse<Product>) => {
        this.products = response
        this.updateTable()
      },
      error: () => alert('Erro ao carregar produtos:')
    });
  }

  deleteProduct(product: Product): void {
    this._productService.delete(product.id)
      .subscribe({
        next: () => {
          this.getProducts(this.paginator!.pageIndex, this.paginator!.pageSize)
        }
      })
  }
}
