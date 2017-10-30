//Angular Components
import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

//App Components
import { MoviesService } from './../../services/movies.service';
import { ActorService } from './../../services/actors.service';

//App Interfaces
import { IMovies } from './../../Interfaces/movies.interface';
import { IActor } from './../../Interfaces/actor.interface';


@Component({

    selector: 'movies-app',
    templateUrl: './movies.component.html'
})

export class MoviesComponent
{
    newMovie: IMovies;
    movies: IMovies;
    actors: IActor;

    constructor(private moviesService: MoviesService, private actorService: ActorService, private router: Router)
    {
        this.getAllMovies();
        this.getAllActors();
    }

    addNewMovie()
    {
        console.log("adas");   
    }

    getAllMovies()
    {
        this.moviesService.getAllMovies().subscribe((movies) => { console.log(movies)});
    }

    getAllActors()
    {
        this.actorService.getAllActors();
    }
}