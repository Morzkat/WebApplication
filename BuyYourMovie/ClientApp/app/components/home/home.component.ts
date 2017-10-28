//Angular Components
import { Component, OnInit } from '@angular/core';

//Angular Material
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

//Services
import { MovieService } from './../../services/movie.service';
import { UserService } from './../../services/user.service';

/*Interfaces*/
//Movie Interface
import { IMovie } from './../../Interfaces/movie.interface';
import { IUser } from './../../Interfaces/user.interface';

//
import { UserControl } from './../userControl'; 

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit
{
    //for movies
    movies: Array<IMovie>;
    updatedMovie: IMovie;

    //user
    User: IUser;
    //user status
    userStatus: boolean = UserControl.getUserStatus;
    constructor(private movieService: MovieService)
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
        this.updatedMovie =
            {
                id,
                movieName,
                movieSipnosis,
                moviePublished,
                movieGender,
                image,
                starts
            };
        this.movieService.putMovie(this.updatedMovie, this.updatedMovie.id)
            .subscribe((response) =>
            {
                console.log(response);
            });
        
        this.getAllMovies();
    }

    movieToPut(oldMovie: IMovie)
    {
        this.updatedMovie = oldMovie;
    } 
}
