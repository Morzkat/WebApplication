import { Injectable } from '@angular/core';

@Injectable()

export class UrlConstans
{

    public static get getServer(): string { return "http://localhost:31280/" };
    public static get getApiUrl(): string { return "api/" };
    public static get serverWithApiUrl(): string { return this.getServer + this.getApiUrl };
}