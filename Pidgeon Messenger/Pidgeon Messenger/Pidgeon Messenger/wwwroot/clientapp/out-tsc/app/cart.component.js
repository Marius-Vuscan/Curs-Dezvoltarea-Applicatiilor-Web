import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { DataService } from './shared/dataService';
let Cart = class Cart {
    constructor(data) {
        this.data = data;
    }
};
Cart = tslib_1.__decorate([
    Component({
        selector: "the-cart",
        templateUrl: "cart.component.html",
        styleUrls: []
    }),
    tslib_1.__metadata("design:paramtypes", [DataService])
], Cart);
export { Cart };
//# sourceMappingURL=cart.component.js.map