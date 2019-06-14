import * as tslib_1 from "tslib";
import { Component, Input } from '@angular/core';
let MessageComponent = class MessageComponent {
    constructor() {
        this.userName = null;
        this.mesage = null;
        this.date = null;
        this.loggedUser = sessionStorage.getItem("userName");
    }
};
tslib_1.__decorate([
    Input(),
    tslib_1.__metadata("design:type", String)
], MessageComponent.prototype, "userName", void 0);
tslib_1.__decorate([
    Input(),
    tslib_1.__metadata("design:type", String)
], MessageComponent.prototype, "mesage", void 0);
tslib_1.__decorate([
    Input(),
    tslib_1.__metadata("design:type", Date)
], MessageComponent.prototype, "date", void 0);
MessageComponent = tslib_1.__decorate([
    Component({
        selector: 'message',
        templateUrl: "./message.component.html",
        styles: []
    })
], MessageComponent);
export { MessageComponent };
//# sourceMappingURL=message.component.js.map