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
    updateMovie: IMovie;

    constructor(private movieService: MovieService )
    {

    }

    ngOnInit()
    {
        this.getAllMovies();
    }

    getAllMovies()
    {
        this.movieService.getAllMovies().subscribe((movie) =>
        {
            this.movies = movie;
        });
    }

    deleteMovie(id:number)
    {
        this.movieService.deleteMovie(id).subscribe((movie) =>
        {
            console.log(movie);
        });
        this.getAllMovies();
    }

    putMovie(id:number, movieName: string, movieSipnosis: string, movieGender: string, moviePublished: string, image: string, starts: number)
    {
        this.updateMovie =
            {
                id,
                movieName,
                movieSipnosis,
                moviePublished,
                movieGender,
                image,
                starts
            };
        this.movieService.putMovie(this.updateMovie, this.updateMovie.id)
            .subscribe((response) =>
            {
                console.log(response);
            });
        
        this.getAllMovies();
       
    }

    movieToPut(oldMovie: IMovie)
    {
        this.updateMovie = oldMovie;
    }
}
