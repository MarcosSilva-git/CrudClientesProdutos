import { HttpClient, HttpParams } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { catchError, Observable, throwError } from 'rxjs'
import { Product } from './models/product.model'
import { environment } from '../../../enviroments/enviroment'
import { PagedResponse } from '../../core/models/paged-response.model'
import { BaseService } from '../../core/services/base.service'

@Injectable({
  providedIn: 'root',
})
export class ProductsService extends BaseService {
  private url: string = `${environment.backend.apiUrl}/product`

  constructor(private http : HttpClient) { super() }

  getProducts(take : number = 5, page : number = 0): Observable<PagedResponse<Product>> {
    const params = new HttpParams()
    .set('take', take.toString())
    .set('page', (page + 1).toString());
    
    return this.http
      .get<PagedResponse<Product>>(this.url, { params })
      .pipe(catchError(this.catchProblemDetailsError));
  }

  deleteProduct(id : number) : Observable<void> {
    return this.http
      .delete<void>(`${this.url}/${id}`)
      .pipe(catchError(this.catchProblemDetailsError))
    }
}
