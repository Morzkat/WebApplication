import { Component, OnInit } from '@angular/core';

//Movie Service
import { MovieService } from './../../services/movie.service';

/*Interfaces*/
//Movie Interface
import { IMovie } from './../../Interfaces/movie.interface';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit
{
    movies: Array<IMovie>;

    constructor(private movieService: MovieService )
    {

    }

    ngOnInit()
    {
        this.movieService.getAllMovies().subscribe((movie) =>{
            console.log(movie);
            this.movies = movie;
        });
    }
}
