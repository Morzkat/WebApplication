//Angular Components
import { Component } from '@angular/core';

//Services
import { MovieService } from './../../services/movie.service';

//interfaces
import { IMovie } from './../../Interfaces/movie.interface';

//Components
@Component({
    selector: 'category-app',
    templateUrl: './category.component.html'
})

export class CategoryComponent
{
    //All movies
    movies: IMovie;

    constructor(private movieService:MovieService)
    {

    }

    //
    ngOnInit()
    {
        //
        this.movieService.getMovieById(19).subscribe((movie) =>
        {
            console.log(movie);
            this.movies = movie; 
        });

        
    }


}