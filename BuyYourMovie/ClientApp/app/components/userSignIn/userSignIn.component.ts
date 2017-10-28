//Angular Components
import { Component } from '@angular/core';

//App Interfaces
import { IUser } from './../../interfaces/user.interface';

@Component
    ({
    selector: 'signIn-user',
    templateUrl:'userSignIn.component.html'
    })

export class UserSignInComponent
{
    User: IUser;
    constructor()
    {
        
    }
}