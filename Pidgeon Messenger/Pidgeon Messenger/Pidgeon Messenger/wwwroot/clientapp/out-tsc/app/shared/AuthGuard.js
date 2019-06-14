import * as tslib_1 from "tslib";
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
let AuthGuard = class AuthGuard {
    constructor(router) {
        this.router = router;
    }
    canActivate() {
        var token = sessionStorage.getItem("token");
        if (token) {
            return true;
        }
        this.router.navigate(["login"]);
        return false;
    }
};
AuthGuard = tslib_1.__decorate([
    Injectable(),
    tslib_1.__metadata("design:paramtypes", [Router])
], AuthGuard);
export { AuthGuard };
//# sourceMappingURL=AuthGuard.js.map