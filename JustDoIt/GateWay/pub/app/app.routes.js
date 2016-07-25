"use strict";
var router_1 = require('@angular/router');
var login_component_1 = require('./login.component');
var home_component_1 = require('./home.component');
var routes = [
    {
        path: "",
        redirectTo: "/home",
        pathMatch: "full"
    },
    {
        path: "login",
        component: login_component_1.LoginComponent
    },
    {
        path: "home",
        component: home_component_1.HomeComponent
    }
];
exports.appRouterProviders = [
    router_1.provideRouter(routes)
];
//# sourceMappingURL=app.routes.js.map