import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogRef, MatDialogModule, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule, MatPrefix } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Product } from '../../models/product.model';
import { ProductsService } from '../../products.service';

export interface ProductCreateUpdateDialogData {
  product?: Product
  title: string
}

type ProductForm = {
  name: FormControl<string | null>;
  price: FormControl<number | null>;
  stock: FormControl<number | null>;
};

@Component({
  selector: 'app-product-create-update-dialog',
  imports: [MatDialogModule, MatPrefix, MatButtonModule, MatFormFieldModule, MatInputModule, ReactiveFormsModule],
  standalone: true,
  templateUrl: './product-create-update-dialog.component.html',
  styleUrl: './product-create-update-dialog.component.css'
})
export class ProductCreateUpdateDialogComponent implements OnInit {
  readonly _productService = inject(ProductsService)
  readonly dialogRef = inject(MatDialogRef<ProductCreateUpdateDialogComponent>);
  readonly data: ProductCreateUpdateDialogData = inject(MAT_DIALOG_DATA);

  productForm = new FormGroup<ProductForm>({
    name: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]),
    price: new FormControl(null, [Validators.required, Validators.min(0.01)]),
    stock: new FormControl(null, [Validators.required, Validators.min(1)])
  });

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
      this.productForm.patchValue(this.data.product ?? {})
  }

  getErrorMessage(field: string) {
    const control = this.productForm.get(field);
    
    if (field == 'n') {
      console.log(control?.value)
    }
    if (control?.hasError('required')) {
      return 'Obrigatório';
    }
    if (control?.hasError('minlength')) {
      return `O ${field} deve ter pelo menos 3 caracteres`;
    }
    if (control?.hasError('maxlength')) {
      return `O ${field} deve ter no máximo 100 caracteres`;
    }
    if (control?.hasError('min')) {
      return field === 'price' ? 'O preço deve ser maior que 0' : 'O estoque deve ser maior que 0';
    }
    return '';
  }

  createProduct(productForm: FormGroup<ProductForm>) {
      const product : Omit<Product, 'id'> = {
        name: this.productForm.value.name!,
        price: this.productForm.value.price!, 
        stock: this.productForm.value.stock!, 
      }
      
      this._productService
        .create(product)
        .subscribe({
          next: () => {
            alert(`Produto criado`)
            this.dialogRef.close(product);
          },
          error: () => {
            alert("Ocorreu um erro inesperado, tente novamente em alguns instantes")
          }
        })
  }

  updateProduct(productForm: FormGroup<ProductForm>) {
    const product : Product = {
      id: this.data.product!.id,
      name: this.productForm.value.name!,
      price: this.productForm.value.price!, 
      stock: this.productForm.value.stock!, 
    }

    this._productService
      .update(product)
      .subscribe({
        next: () => {
          alert(`Produto atualizado`)
          this.dialogRef.close(product);
        },
        error: () => {
          alert("Ocorreu um erro inesperado, tente novamente em alguns instantes")
        }
      })
  }

  submit() {
    if (this.productForm.valid) {
      if (this.data.product) {
        this.updateProduct(this.productForm)
      } else {
          this.createProduct(this.productForm)
      } 
    }
  }
}
