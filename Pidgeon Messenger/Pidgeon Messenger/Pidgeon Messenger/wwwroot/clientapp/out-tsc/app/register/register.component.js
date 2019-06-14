import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../shared/dataService';
let Register = class Register {
    constructor(data, router) {
        this.data = data;
        this.router = router;
        this.errorMessage = "";
        this.creds = {
            email: "",
            username: "",
            password: ""
        };
    }
    onRegister() {
        this.data.register(this.creds)
            .subscribe(success => {
            if (success) {
                this.router.navigate(["chatList"]);
            }
        }, err => this.errorMessage = "Failed to Register");
    }
};
Register = tslib_1.__decorate([
    Component({
        selector: "register",
        templateUrl: "register.component.html"
    }),
    tslib_1.__metadata("design:paramtypes", [DataService, Router])
], Register);
export { Register };
//# sourceMappingURL=register.component.js.map