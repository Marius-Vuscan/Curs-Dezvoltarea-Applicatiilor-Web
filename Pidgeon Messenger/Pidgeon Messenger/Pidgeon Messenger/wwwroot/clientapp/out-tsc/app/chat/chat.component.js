import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../shared/dataService';
import { SignalRService } from '../shared/signalRService';
let ChatComponent = class ChatComponent {
    constructor(router, route, data, signalRService) {
        this.router = router;
        this.route = route;
        this.data = data;
        this.signalRService = signalRService;
        this.title = 'pidgeon-app';
        this.errorMessage = "";
        this.successMessage = "";
    }
    ngOnInit() {
        this.route.params.subscribe(params => {
            this.groupId = params['id'];
        });
        this.data.loadMessages(this.groupId)
            .subscribe(success => {
            if (success) {
                this.group = this.data.group;
            }
        });
        this.signalRService.startConnection();
        this.signalRService.addGroupRecieveMessageListener(this.groupId);
    }
    ngOnDestroy() {
        this.signalRService.stopConnection();
    }
    ngSendMessage(message) {
        var messagesUl = document.querySelector('#messagesUl');
        this.data.sendMessages(message, this.groupId)
            .subscribe(success => {
            if (success) {
            }
        });
    }
    ngAddUser(userName) {
        this.data.addUser(userName, this.groupId)
            .subscribe(success => {
            if (success) {
                this.successMessage = "User added to group!";
            }
        }, err => this.errorMessage = "Failed to add user!");
    }
};
ChatComponent = tslib_1.__decorate([
    Component({
        selector: 'chat',
        templateUrl: "./chat.component.html",
        styleUrls: ["./chat.component.css"]
    }),
    tslib_1.__metadata("design:paramtypes", [Router, ActivatedRoute, DataService, SignalRService])
], ChatComponent);
export { ChatComponent };
//# sourceMappingURL=chat.component.js.map