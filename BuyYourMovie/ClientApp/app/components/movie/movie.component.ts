//Angular Components
import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

//App Components
import { MovieService } from './../../services/movie.service';

//App Interfaces
import { IMovie } from './../../Interfaces/movie.interface';


@Component({

    selector: 'movie-app',
    templateUrl: './movie.component.html'
})

export class MovieComponent 
{
    newMovie: IMovie;
    

    constructor(private movieService: MovieService, private router: Router)
    {

    }

    addNewMovie(movieName: string, movieSipnosis: string, movieGender: string, moviePublished: string, image: string, starts:number)
    {
      let id: number = 1;
      this.newMovie =
          {
            id,
            movieName,
            movieSipnosis,
            moviePublished,
            movieGender,
            image,
            starts
          };

      this.movieService.postMovie(this.newMovie);
      this.router.navigateByUrl('/home');
      
    }
}