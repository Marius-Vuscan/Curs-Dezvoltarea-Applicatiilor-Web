import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { Router } from '@angular/router';
let HomeComponent = class HomeComponent {
    constructor(router) {
        this.router = router;
        this.title = 'pidgeon-app';
    }
};
HomeComponent = tslib_1.__decorate([
    Component({
        selector: 'home',
        templateUrl: "./home.component.html",
        styles: []
    }),
    tslib_1.__metadata("design:paramtypes", [Router])
], HomeComponent);
export { HomeComponent };
//# sourceMappingURL=home.component.js.map