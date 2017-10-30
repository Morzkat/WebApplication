//Angular Components
import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

//App Components
import { MoviesService } from './../../services/movies.service';

//App Interfaces
import { IMovies } from './../../Interfaces/movies.interface';


@Component({

    selector: 'movies-app',
    templateUrl: './movies.component.html'
})

export class MoviesComponent
{
    newMovie: IMovies;
    movies: IMovies;

    constructor(private moviesService: MoviesService, private router: Router)
    {
        this.getAllMovies();
    }

    addNewMovie()
    {
        console.log("adas");   
    }

    getAllMovies()
    {
        this.moviesService.getAllMovies().subscribe((movies) => { console.log(movies)});
    }
}