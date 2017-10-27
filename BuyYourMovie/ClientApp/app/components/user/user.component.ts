//Angular Components
import { Component } from '@angular/core';

//App Interfaces
import { IUser } from './../../interfaces/user.interface';

@Component
    ({
    selector: 'app-user',
    templateUrl:'user.component.html'
    })

export class UserComponent
{
    User: IUser;
    constructor()
    {
        
    }
}