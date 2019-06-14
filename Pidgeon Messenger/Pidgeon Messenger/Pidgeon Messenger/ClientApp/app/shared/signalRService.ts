import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { ActivatedRoute } from '@angular/router';
import { DataService } from './dataService';
import * as moment from 'moment';

@Injectable()
export class SignalRService {
    private hubConnection: signalR.HubConnection;

    constructor(private route: ActivatedRoute, private data: DataService) {

    }

    public startConnection = () => {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl('https://localhost:44309/hub')
            .build();

        this.hubConnection
            .start()
            .then(() => console.log('Connection started'))
            .catch(err => console.log('Error while starting connection: ' + err));
    }

    public stopConnection = () => {
        this.hubConnection.stop();
    }

    public addGroupRecieveMessageListener = (groupRoomId) => {
        this.hubConnection.on('sendMessageToGroup', (userName, groupId, message) => {
            if (groupId == groupRoomId) {
                this.data.group.message.push({
                    message1: message,
                    user: { userName: userName },
                    date: moment(new Date()).format('MMMM Do YYYY, h:mm:ss a')
                });
            }
        });
    }
}