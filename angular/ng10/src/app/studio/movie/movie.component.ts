import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { MovieService } from './movie.service';
import { Movie } from './movie.type';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  movies$: Observable<Movie[]>;

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.movies$ = this.movieService.get();
  }
}
