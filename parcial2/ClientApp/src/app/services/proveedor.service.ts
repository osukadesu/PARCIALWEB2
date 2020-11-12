import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { catchError, map, tap } from 'rxjs/operators';
import { Proveedor } from '../parcial2/models/proveedor';

@Injectable({
  providedIn: 'root'
})
export class ProveedorService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Proveedor[]> {
    return this.http.get<Proveedor[]>(this.baseUrl + 'api/Proveedor')
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Proveedor[]>('Consulta Proveedor', null))
      );
  }
  post(proveedor: Proveedor): Observable<Proveedor> {
    return this.http.post<Proveedor>(this.baseUrl + 'api/Proveedor', proveedor)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Proveedor>('Registrar Proveedor', null))
      );
  }

}