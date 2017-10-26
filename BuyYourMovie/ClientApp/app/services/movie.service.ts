//Angular Components
import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions} from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Rx';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

//Configuration / API 
import { UrlConstans } from './../../app/config';

//Interfaces
//Movie Interface
import { IMovie } from './../Interfaces/movie.interface';

/*Movie Component*/
import { MovieComponent } from './../components/movie/movie.component';

@Injectable()
    export class MovieService
{

    constructor(private http: Http, private http2 : HttpClient)
    {
        
    }

    getAllMovies(): Observable<Array<IMovie>>
    {
        return this.http.get(UrlConstans.serverWithApiUrl + "movies/")
            .map(response => response.json() as Array<IMovie>);

    }

    getByCategory(category: string): Observable<Array<IMovie>>
    {
        return this.http.get(UrlConstans.serverWithApiUrl + "movies/" + category)
            .map(response => response.json() as Array<IMovie>);
    }

    getMovieById(id: number):Observable <IMovie>
    {
        return this.http.get(UrlConstans.serverWithApiUrl + "movies/" + id)
            .map(response => response.json() as IMovie);
    }

    postMovie(movie: IMovie)
    {
        let body = JSON.stringify(movie);
        let header = new Headers();
        header.append('Content-Type', 'application/json');

        let options = new RequestOptions({ headers: header });

        return this.http2.post('http://localhost:31280/api/movies', body)
            .subscribe(resp => resp);
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
