import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../shared/dataService';

@Component({
    selector: 'chatList',
    templateUrl: "./chatList.component.html",
    styles: []
})
export class ChatListComponent implements OnInit {
    title = 'pidgeon-app';
    public chats: any[] = [];
    errorMessage: string = "";

    constructor(private router: Router, private data: DataService) {

    }

    ngOnInit(): void {
        this.data.loadGroups()
            .subscribe(success => {
                if (success) {
                    this.chats = this.data.groups;
                }
            });
    }

    goToGroup(groupId: any): void{
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
}
