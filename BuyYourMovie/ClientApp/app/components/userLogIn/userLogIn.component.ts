import { Component } from '@angular/core';
import { Router } from '@angular/router';

//
import { UserService } from './../../services/user.service';

//
import { IUser } from './../../interfaces/user.interface'; 

//
import { UserControl } from './../userControl';

@Component({
    selector: 'logIn-app',
    templateUrl: 'userLogIn.component.html',
    inputs: ['getUser']
})

export class UserLogInComponent
{
    user: IUser;
    constructor(private userService: UserService, private router:Router) { };

    logIn(email:string, pw:string)
    {
        this.userService.getUser(email, pw ).subscribe((user) =>
        {
            UserControl.setUserStatus(true);
            UserControl.setUser(user);

            this.router.navigateByUrl('/home');
        });
    }
}