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
import { IUser } from './../Interfaces/user.interface';

/*Movie Component*/
import { MovieComponent } from './../components/movie/movie.component';

@Injectable()
export class UserService
{
    private static userStatus: boolean = true;

    constructor(private http: Http, private http2: HttpClient)
    {}

    //User status getter and setter
    public static get getUserStatus(): boolean { return this.userStatus }
    public static set SetUserStatus(status: boolean) { this.userStatus = status }

    getUser(token: string): Observable<IUser>
    {
        return this.http.get(UrlConstans.serverWithApiUrl + "users/token?token=" + token)
            .map(response => response.json() as IUser);
    }

    getUserById(id: number): Observable<IUser>
    {
        return this.http.get(UrlConstans.serverWithApiUrl + "users/" + id)
            .map(response => response.json() as IUser);
    }

    postUser(user: IUser)
    {
        return this.http.post(UrlConstans.serverWithApiUrl + "users", user)
            .subscribe(res => res.json());
    }

    putUser(user: IUser, id: number): Observable<any>
    {
        return this.http.put(UrlConstans.serverWithApiUrl + "users/" + id, user)
            .map(res => res.json());
    }

    deleteUser(id: number)
    {
        return this.http.delete(UrlConstans.serverWithApiUrl + "users/" + id)
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
