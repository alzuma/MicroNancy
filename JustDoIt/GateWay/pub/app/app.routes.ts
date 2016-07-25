import { provideRouter, RouterConfig }  from '@angular/router';
import { LoginComponent } from './login.component';
import { HomeComponent } from './home.component';

const routes: RouterConfig = [
    {
        path: "",
        redirectTo: "/home",
        pathMatch: "full"
    },
    {
        path: "login",
        component: LoginComponent
    },
    {
        path: "home",
        component: HomeComponent
    }
];

export const appRouterProviders = [
    provideRouter(routes)
];