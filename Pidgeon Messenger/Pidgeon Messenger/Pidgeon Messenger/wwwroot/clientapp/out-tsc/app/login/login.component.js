import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../shared/dataService';
let Login = class Login {
    constructor(data, router) {
        this.data = data;
        this.router = router;
        this.errorMessage = "";
        this.creds = {
            username: "",
            password: ""
        };
    }
    onLogin() {
        this.data.login(this.creds)
            .subscribe(success => {
            if (success) {
                this.router.navigate(["chatList"]);
            }
        }, err => this.errorMessage = "Failed to login");
    }
};
Login = tslib_1.__decorate([
    Component({
        selector: "login",
        templateUrl: "login.component.html"
    }),
    tslib_1.__metadata("design:paramtypes", [DataService, Router])
], Login);
export { Login };
//# sourceMappingURL=login.component.js.map