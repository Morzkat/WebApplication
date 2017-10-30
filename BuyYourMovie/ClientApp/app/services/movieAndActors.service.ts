//Angular Components
import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Rx';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

//Configuration / API 
import { UrlConstans } from './../../app/config';

//Interfaces
//Movie Interface
import { IMovie } from './../Interfaces/movie.interface';
import { IActor } from './../Interfaces/actor.interface';

/*Movie Component*/
import { MovieComponent } from './../components/movie/movie.component';

@Injectable()
export class MovieService {

    constructor(private http: Http, private http2: HttpClient) {

    }

    getAllMoviesAndActors(): Observable<Array<IMovie>> {
        return this.http.get(UrlConstans.serverWithApiUrl + "MovieAndActorsModels/")
            .map(response => response.json() as Array<IMovie>);

    }
    
    getMoviesAndActorsById(id: number): Observable<IMovie> {
        return this.http.get(UrlConstans.serverWithApiUrl + "MovieAndActorsModels/" + id)
            .map(response => response.json() as IMovie);
    }

    postMovie(movie: IMovie, actor: IActor)
    {
        return this.http.post(UrlConstans.serverWithApiUrl + "MovieAndActorsModels/movieName=", movie)
            .subscribe(res => res.json());
    }

    putMovie(movie: IMovie, id: number): Observable<any> {
        return this.http.put(UrlConstans.serverWithApiUrl + "MovieAndActorsModels/" + id, movie)
            .map(res => res.json());
    }

    deleteMovie(id: number)
    {
        return this.http.delete(UrlConstans.serverWithApiUrl + "MovieAndActorsModels/" + id)
            .map(res => res.json());
    }

    private handleError(err: HttpErrorResponse) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        let errorMessage = '';
        if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            errorMessage = `An error occurred: ${err.error.message}`;
        } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return Observable.throw(errorMessage);
    }

}
