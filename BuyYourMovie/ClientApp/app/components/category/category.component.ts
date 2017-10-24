import { Component } from '@angular/core';


import { UserService } from './../../services/user.service';
@Component({
    selector: 'category-app',
    templateUrl: './category.component.html'
})

export class CategoryComponent
{
    posts: Array<Post>;
    some: Array<string> = [];

    constructor(private userService:UserService)
    {

    }

    ngOnInit()
    {
    

        this.userService.getPosts().subscribe((post) => {
            this.posts = post;
        });

        this.userService.getT().subscribe((some) =>
        {
            this.some = some;
            console.log(some);
            console.log(this.some);
        });

        
    }


}

interface Post {

    id: number,
    body: string,
    title: string,
    userId: number
}