import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthGuard } from '../shared/AuthGuard';

@Component({
    selector: 'navbar',
    templateUrl: "./navbar.component.html",
    styles: []
})
export class NavbarComponent {
    constructor(private router: Router, private authGuard: AuthGuard) {

    }

    public canActivate = this.authGuard.canActivate();

    onLogin() {
        this.router.navigate(["login"]);
    }

    onRegister() {
        this.router.navigate(["register"]);
    }

    onLogOut() {
        sessionStorage.removeItem("token");
        this.router.navigate(["/"]);
    }
    onchatList() {
        this.router.navigate(["chatList"]);
    }
}
