import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Movie } from './movie.type';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  private baseUrl = environment.serviceUrls.api;

  constructor(private http: HttpClient) {}

  get(): Observable<Movie[]> {
    return this.http.get<Movie[]>(`${this.baseUrl}/api/movie`);
  }

  getOne(id: string): Observable<Movie> {
    return this.http.get<Movie>(`${this.baseUrl}/api/movie/${id}`);
  }
}
