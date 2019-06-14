import { Component, Input } from '@angular/core';

@Component({
    selector: 'message',
    templateUrl: "./message.component.html",
    styles: []
})
export class MessageComponent {
    @Input() userName: string | null = null;
    @Input() mesage: string | null = null;
    @Input() date: Date | null = null;

    public loggedUser: string | null = sessionStorage.getItem("userName");
}
