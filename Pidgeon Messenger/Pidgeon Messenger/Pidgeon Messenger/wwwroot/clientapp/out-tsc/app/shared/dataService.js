import * as tslib_1 from "tslib";
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
let DataService = class DataService {
    constructor(http) {
        this.http = http;
        this.products = [];
        this.groups = [];
    }
    loadMessages(groupId) {
        return this.http.get("/Chat/GetGroup", {
            params: new HttpParams().set("groupId", groupId),
            headers: new HttpHeaders({
                "Authorization": "Bearer " + sessionStorage.getItem('token'),
                "Content-Type": "application/json"
            })
        }).pipe(map((data) => {
            this.group = data;
            return true;
        }));
    }
    sendMessages(message, groupId) {
        return this.http.get("/Chat/SendMessage", {
            params: new HttpParams().set("groupId", groupId).set("message", message),
            headers: new HttpHeaders({
                "Authorization": "Bearer " + sessionStorage.getItem('token'),
                "Content-Type": "application/json"
            })
        }).pipe(map((data) => {
            return true;
        }));
    }
    loadGroups() {
        return this.http.get("/Chat/GetUserGroups", {
            headers: new HttpHeaders({
                "Authorization": "Bearer " + sessionStorage.getItem('token'),
                "Content-Type": "application/json"
            })
        }).pipe(map((data) => {
            this.groups = data;
            return true;
        }));
    }
    addUser(userName, groupId) {
        return this.http.get("/Chat/AddUserInGroup", {
            params: new HttpParams().set("groupId", groupId).set("userName", userName),
            headers: new HttpHeaders({
                "Authorization": "Bearer " + sessionStorage.getItem('token'),
                "Content-Type": "application/json"
            })
        }).pipe(map((data) => {
            return true;
        }));
    }
    createGroup(groupName) {
        return this.http.get("/Chat/CreateGroup", {
            params: new HttpParams().set("groupName", groupName),
            headers: new HttpHeaders({
                "Authorization": "Bearer " + sessionStorage.getItem('token'),
                "Content-Type": "application/json"
            })
        }).pipe(map((data) => {
            return true;
        }));
    }
    login(creds) {
        return this.http
            .post("/Account/Login", creds)
            .pipe(map((data) => {
            sessionStorage.setItem('token', data.token);
            sessionStorage.setItem('userName', creds.username);
            return true;
        }));
    }
    register(creds) {
        return this.http
            .post("/Account/Register", creds)
            .pipe(map((data) => {
            sessionStorage.setItem('token', data.token);
            sessionStorage.setItem('userName', creds.username);
            return true;
        }));
    }
    logOut() {
        sessionStorage.removeItem("token");
        sessionStorage.removeItem('userName');
    }
};
DataService = tslib_1.__decorate([
    Injectable(),
    tslib_1.__metadata("design:paramtypes", [HttpClient])
], DataService);
export { DataService };
//# sourceMappingURL=dataService.js.map