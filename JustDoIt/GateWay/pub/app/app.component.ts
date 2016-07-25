import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';
import { HomeComponent } from './home.component';
import { LoginComponent } from './login.component';

@Component({
    selector: 'my-app',
    template: ` <h1>Micro service with Nancy</h1>
                <router-outlet></router-outlet>`,
    directives: [ROUTER_DIRECTIVES],
    precompile: [HomeComponent, LoginComponent]
})
export class AppComponent { }