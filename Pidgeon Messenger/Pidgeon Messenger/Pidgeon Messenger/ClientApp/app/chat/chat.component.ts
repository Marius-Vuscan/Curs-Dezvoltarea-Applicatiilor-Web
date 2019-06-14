import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../shared/dataService';
import { SignalRService } from '../shared/signalRService';

@Component({
    selector: 'chat',
    templateUrl: "./chat.component.html",
    styleUrls: ["./chat.component.css"]
})
export class ChatComponent implements OnInit, OnDestroy {
    title = 'pidgeon-app';

    public group;
    public groupId;
    errorMessage: string = "";
    successMessage: string = "";

    constructor(private router: Router, private route: ActivatedRoute, private data: DataService, private signalRService: SignalRService) {

    }

    ngOnInit(): void {
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

    ngOnDestroy(): void {
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
                    this.successMessage = "User added to group!"
                }
            }, err => this.errorMessage = "Failed to add user!");
    }
}
