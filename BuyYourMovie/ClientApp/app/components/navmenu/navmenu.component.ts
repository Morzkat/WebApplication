import { Component } from '@angular/core';

import { UserControl } from './../userControl';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html'
})
export class NavMenuComponent
{
    userStatus: boolean = UserControl.getUserStatus;
    constructor()
    {
    }
}
