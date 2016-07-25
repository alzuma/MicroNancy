import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class LoginService {
    private loginUrl = 'api/gateway/login';

    constructor(private http: Http) { }

    login() {
        return this.http.get(this.loginUrl).toPromise().then(response => response.json().data);
    }
}