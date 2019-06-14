import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'home',
    templateUrl: "./home.component.html",
    styles: []
})
export class HomeComponent {
    title = 'pidgeon-app';

    constructor(private router: Router) {

    }
}
