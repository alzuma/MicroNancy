import { Component } from '@angular/core';
import { LoginService } from './authentication/login.service';

@Component({
    selector: 'login',
    template: 'empty',
    providers: [LoginService]
})
export class LoginComponent {
    constructor(private loginService: LoginService) {
       loginService.login();
    }
}