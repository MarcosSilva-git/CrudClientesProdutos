import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { catchError, Observable, throwError } from 'rxjs'
import { Product } from './models/product.model'
import { environment } from '../../../enviroments/enviroment'
import { PagedResponse } from '../../core/models/paged-response.model'
import { BackendError } from '../../core/models/backend-error.model'

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  constructor(private http : HttpClient) { }

  getProducts(): Observable<PagedResponse<Product>> {
    return this.http.get<PagedResponse<Product>>(`${environment.backend.apiUrl}/product`).pipe(
      catchError(error => {
        const apiError: BackendError = {
          status: error.status,
          title: error.error?.title,
          detail: error.error?.detail
        };

        console.log(error)
        return throwError(() => apiError);
      })
    );
  }
}
