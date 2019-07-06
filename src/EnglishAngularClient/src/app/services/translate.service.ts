import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Language } from '../domain/models/language';
import { AppConfig } from '../app.config';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})

export class TranslateService {
  constructor(private config: AppConfig, private http: HttpClient) { }

  getAll(): Observable<Language[]> {
    return this.http.get<Language[]>(this.config.urls.GetAllLanguages).pipe(
      tap(_ => this.log(`fetched Languages ${JSON.stringify(_)}`)),
      catchError(this.handleError('getAll'))
    );
  }

  private log(message: string) {
    console.log(`TranslateService: ${message}`);
  }

  private handleError(operation = 'operation') {
    return (error: any): Observable<any> => {

      this.log(`${operation} failed: ${error.message}`);

      return throwError(error);
    };
  }
}
