import { HttpClient, HttpParams } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { catchError, Observable, throwError } from 'rxjs'
import { Client } from './models/client.model'
import { environment } from '../../../enviroments/enviroment'
import { PagedResponse } from '../../core/models/paged-response.model'
import { BaseService } from '../../core/services/base.service'

@Injectable({
  providedIn: 'root',
})
export class ClientsService extends BaseService {
  private url: string = `${environment.backend.apiUrl}/client`

  constructor(private http : HttpClient) { super() }

  get(take : number = 5, page : number = 0): Observable<PagedResponse<Client>> {
    const params = new HttpParams()
    .set('take', take.toString())
    .set('page', (page + 1).toString());
    
    return this.http
      .get<PagedResponse<Client>>(this.url, { params })
      .pipe(catchError(this.catchProblemDetailsError));
  }

  create(client : Omit<Client, "id">) : Observable<Client> {

    return this.http
      .post<Client>(`${this.url}`, client)
      .pipe(catchError(this.catchProblemDetailsError))
  }

  update(client : Client) : Observable<Client> {
    return this.http
      .put<Client>(`${this.url}/${client.id}`, client)
      .pipe(catchError(this.catchProblemDetailsError))
  }

  delete(id : number) : Observable<void> {
    return this.http
      .delete<void>(`${this.url}/${id}`)
      .pipe(catchError(this.catchProblemDetailsError))
    }
}
