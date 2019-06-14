import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../shared/dataService';

@Component({
    selector: "register",
    templateUrl: "register.component.html"
})
export class Register {
    constructor(private data: DataService, private router: Router) {

    }

    errorMessage: string = "";
    public creds = {
        email: "",
        username: "",
        password: ""
    };

    onRegister() {
        this.data.register(this.creds)
            .subscribe(success => {
                if (success) {
                    this.router.navigate(["chatList"]);
                }
            }, err => this.errorMessage = "Failed to Register")
    }
}