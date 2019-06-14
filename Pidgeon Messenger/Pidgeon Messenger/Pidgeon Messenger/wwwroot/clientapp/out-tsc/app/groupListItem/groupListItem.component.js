import * as tslib_1 from "tslib";
import { Component, Input } from '@angular/core';
let GroupListItemComponent = class GroupListItemComponent {
    constructor() {
        this.groupName = null;
        this.groupId = null;
    }
};
tslib_1.__decorate([
    Input(),
    tslib_1.__metadata("design:type", String)
], GroupListItemComponent.prototype, "groupName", void 0);
tslib_1.__decorate([
    Input(),
    tslib_1.__metadata("design:type", String)
], GroupListItemComponent.prototype, "groupId", void 0);
GroupListItemComponent = tslib_1.__decorate([
    Component({
        selector: 'groupListItem',
        templateUrl: "./groupListItem.component.html",
        styles: []
    })
], GroupListItemComponent);
export { GroupListItemComponent };
//# sourceMappingURL=groupListItem.component.js.map