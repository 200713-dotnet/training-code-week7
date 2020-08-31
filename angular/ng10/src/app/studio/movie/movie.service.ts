import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from './movie.type';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  private baseUrl = 'http://localhost:8000';

  constructor(private http: HttpClient) {}

  get(): Observable<Movie[]> {
    return this.http.get<Movie[]>(`${this.baseUrl}/api/movie`);
  }

  getOne(id: string): Observable<Movie> {
    return this.http.get<Movie>(`${this.baseUrl}/api/movie/${id}`);
  }
}
