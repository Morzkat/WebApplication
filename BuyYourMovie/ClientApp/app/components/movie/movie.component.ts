//Angular Components
import { Component } from '@angular/core';
import { Http } from '@angular/http';

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
    

    constructor(private movieService: MovieService)
    {

    }

    addNewMovie(movieName: string, movieSipnosis: string, movieGender: string, moviePublished: string, image: string, starts:number)
    {
      this.newMovie =
        {
            movieName,
            movieSipnosis,
            moviePublished,
            movieGender,
            image,
            starts
        };

      this.movieService.postMovie(this.newMovie);

      console.log(this.newMovie);
      
    }
}