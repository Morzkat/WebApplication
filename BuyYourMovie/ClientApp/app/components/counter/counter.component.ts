//Angular Components
import { Component, OnInit } from '@angular/core';

//App services
import { UserService } from './../../services/user/user.service';

@Component
({
    selector: 'counter',
    templateUrl: './counter.component.html'
})

export class CounterComponent implements OnInit
{
    posts: Array<Post>;

    public currentCount = 0;

    public incrementCounter()
    {
        this.currentCount++;
    }

    constructor(private userService:UserService)
    {

    }

    ngOnInit()
    {
        this.userService.getPosts().subscribe((post) =>
        {
            this.posts = post;
        });
    }
}

interface Post
{

    id: number,
    body: string,
    title: string,
    userId: number
}
