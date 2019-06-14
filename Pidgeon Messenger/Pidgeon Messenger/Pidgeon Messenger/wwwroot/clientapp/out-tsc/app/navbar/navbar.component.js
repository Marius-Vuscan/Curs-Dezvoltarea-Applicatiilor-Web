import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthGuard } from '../shared/AuthGuard';
let NavbarComponent = class NavbarComponent {
    constructor(router, authGuard) {
        this.router = router;
        this.authGuard = authGuard;
        this.canActivate = this.authGuard.canActivate();
    }
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
};
NavbarComponent = tslib_1.__decorate([
    Component({
        selector: 'navbar',
        templateUrl: "./navbar.component.html",
        styles: []
    }),
    tslib_1.__metadata("design:paramtypes", [Router, AuthGuard])
], NavbarComponent);
export { NavbarComponent };
//# sourceMappingURL=navbar.component.js.map