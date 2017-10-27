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
    movies: Array<IMovie>;

    constructor(private movieService:MovieService)
    {

    }

    //
    ngOnInit()
    {
        this.getMoviesByGender("Accion");
    }

    getMoviesByGender(gender:string)
    {
        this.movieService.getByGender(gender).subscribe((movie) =>
        {   this.movies = movie;    });
    }

    getGender(gender:string)
    {
        this.getMoviesByGender(gender);
    }
}