import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-movie',
  templateUrl: './fetch-movie.component.html'
})
export class FetchMovieComponent {
  public movies: Movie[];

  constructor(http: HttpClient) {
    http.get<Movie[]>('https://localhost:44364/api/movies').subscribe(result => {
      this.movies = result;
      console.dir(this.movies);
    }, error => console.error(error));
  }
}

interface Movie {
  id: number;
  name: string;
  year: number;
}
