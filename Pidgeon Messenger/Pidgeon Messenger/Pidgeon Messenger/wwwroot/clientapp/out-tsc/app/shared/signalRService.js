import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { ActivatedRoute } from '@angular/router';
import { DataService } from './dataService';
import * as moment from 'moment';
let SignalRService = class SignalRService {
    constructor(route, data) {
        this.route = route;
        this.data = data;
        this.startConnection = () => {
            this.hubConnection = new signalR.HubConnectionBuilder()
                .withUrl('https://localhost:44309/hub')
                .build();
            this.hubConnection
                .start()
                .then(() => console.log('Connection started'))
                .catch(err => console.log('Error while starting connection: ' + err));
        };
        this.stopConnection = () => {
            this.hubConnection.stop();
        };
        this.addGroupRecieveMessageListener = (groupRoomId) => {
            this.hubConnection.on('sendMessageToGroup', (userName, groupId, message) => {
                if (groupId == groupRoomId) {
                    this.data.group.message.push({
                        message1: message,
                        user: { userName: userName },
                        date: moment(new Date()).format('MMMM Do YYYY, h:mm:ss a')
                    });
                }
            });
        };
    }
};
SignalRService = tslib_1.__decorate([
    Injectable(),
    tslib_1.__metadata("design:paramtypes", [ActivatedRoute, DataService])
], SignalRService);
export { SignalRService };
//# sourceMappingURL=signalRService.js.map