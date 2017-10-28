import { Injectable } from '@angular/core';

import { IUser } from './../Interfaces/user.interface';

@Injectable()

export class UserControl
{
    private static user: IUser;
    private static userStatus: boolean = false;

    public static get getUserStatus(): boolean { return this.userStatus };
    public static setUserStatus(status: boolean) { this.userStatus = status };

    public static get getUser(): IUser { return this.user };
    public static setUser(user: IUser)
    { (user != null) ? this.user = user : this.userStatus = false; };
}