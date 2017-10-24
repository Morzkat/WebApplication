import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Rx';
import { HttpClientXsrfModule } from '@angular/common/http';


import { Post } from './../Interfaces/movie.interface';

@Injectable()
    export class UserService
{
    public server = "http://localhost:31280/";
    public apiUrl = "api/";

    public serverWithApiUrl = this.server + this.apiUrl;

    private actionUrl: string;

    constructor(private http: Http)
    {
        this.actionUrl = this.serverWithApiUrl + 'values';
    }

    getPosts(): Observable<Array<Post>>
    {
        return this.http.get('https://jsonplaceholder.typicode.com/posts').map(response => response.json() as Array<Post>);

    }

    getT()
    {
        return this.http.get(this.actionUrl).map(response => response.json());
    }
}
