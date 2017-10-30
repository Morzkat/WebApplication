//Angular Components
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

//App Components
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { CategoryComponent } from './components/category/category.component';
import { MovieComponent } from './components/movie/movie.component';
import { UserSignInComponent } from './components/userSignIn/userSignIn.component';
import { UserLogInComponent } from './components/userLogIn/userLogIn.component';
//import { ActorsComponent } from './components/actors/actors.component';

//App services
import { MovieService } from './services/movie.service';
import { UserService } from './services/user.service';

//routes of the app 
const appRoutes:Routes =
[
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'category', component: CategoryComponent },
    { path: 'newMovie', component: MovieComponent },
    { path: 'signIn', component: UserSignInComponent },
    { path: 'logIn', component: UserLogInComponent },
    { path: '**', redirectTo: 'home' },
]

@NgModule({
    declarations:
    [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CategoryComponent,
        MovieComponent,
        UserSignInComponent,
        UserLogInComponent,
    ],

    imports:
    [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot(appRoutes),
        HttpClientModule
        
    ],

    providers:
    [
        UserService,
        MovieService,
    ]
})
export class AppModuleShared {
}
