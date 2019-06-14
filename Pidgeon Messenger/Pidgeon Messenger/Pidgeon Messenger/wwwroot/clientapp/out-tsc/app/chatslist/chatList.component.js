import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../shared/dataService';
let ChatListComponent = class ChatListComponent {
    constructor(router, data) {
        this.router = router;
        this.data = data;
        this.title = 'pidgeon-app';
        this.chats = [];
        this.errorMessage = "";
    }
    ngOnInit() {
        this.data.loadGroups()
            .subscribe(success => {
            if (success) {
                this.chats = this.data.groups;
            }
        });
    }
    goToGroup(groupId) {
        this.router.navigate(["chat", { id: groupId }]);
    }
    ngaddGroup(groupName) {
        this.data.createGroup(groupName)
            .subscribe(success => {
            if (success) {
                window.location.reload();
            }
        }, err => this.errorMessage = "Failed to create group!");
    }
};
ChatListComponent = tslib_1.__decorate([
    Component({
        selector: 'chatList',
        templateUrl: "./chatList.component.html",
        styles: []
    }),
    tslib_1.__metadata("design:paramtypes", [Router, DataService])
], ChatListComponent);
export { ChatListComponent };
//# sourceMappingURL=chatList.component.js.map