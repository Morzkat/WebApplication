//Angular Components
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

//App Components
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { CategoryComponent } from './components/category/category.component';

//App services
import { UserService } from './services/user/user.service';

//routes of the app 
const appRoutes:Routes =
[
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'category', component:CategoryComponent },
    { path: '**', redirectTo: 'home' }
]

@NgModule({
    declarations:
    [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CategoryComponent
    ],

    imports:
    [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot(appRoutes)
    ],

    providers:
    [
        UserService
    ]
})
export class AppModuleShared {
}
