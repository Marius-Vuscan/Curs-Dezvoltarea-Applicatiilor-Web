import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class DataService {
    public products = [];
    public groups = [];
    public group: any;

    constructor(private http: HttpClient) {

    }

    loadMessages(groupId: any): Observable<boolean> {
        return this.http.get("/Chat/GetGroup", {
            params: new HttpParams().set("groupId", groupId),
            headers: new HttpHeaders({
                "Authorization": "Bearer " + sessionStorage.getItem('token'),
                "Content-Type": "application/json"
            })
        }).pipe(
            map((data: any[]) => {
                this.group = data;
                return true;
            }));
    }

    sendMessages(message:any,groupId:any): Observable<boolean> {
        return this.http.get("/Chat/SendMessage", {
            params: new HttpParams().set("groupId", groupId).set("message", message),
            headers: new HttpHeaders({
                "Authorization": "Bearer " + sessionStorage.getItem('token'),
                "Content-Type": "application/json"
            })
        }).pipe(
            map((data: any[]) => {
                return true;
            }));
    }

    loadGroups(): Observable<boolean> {
        return this.http.get("/Chat/GetUserGroups", {
            headers: new HttpHeaders({
                "Authorization": "Bearer " + sessionStorage.getItem('token'),
                "Content-Type": "application/json"
            })
        }).pipe(
            map((data: any[]) => {
                this.groups = data;
                return true;
            }));
    }

    addUser(userName, groupId): Observable<boolean> {
        return this.http.get("/Chat/AddUserInGroup", {
            params: new HttpParams().set("groupId", groupId).set("userName", userName),
            headers: new HttpHeaders({
                "Authorization": "Bearer " + sessionStorage.getItem('token'),
                "Content-Type": "application/json"
            })
        }).pipe(
            map((data: any[]) => {
                return true;
            }));
    }

    createGroup(groupName): Observable<boolean> {
        return this.http.get("/Chat/CreateGroup", {
            params: new HttpParams().set("groupName", groupName),
            headers: new HttpHeaders({
                "Authorization": "Bearer " + sessionStorage.getItem('token'),
                "Content-Type": "application/json"
            })
        }).pipe(
            map((data: any[]) => {
                return true;
            }));
    }

    login(creds): Observable<boolean> {
        return this.http
            .post("/Account/Login", creds)
            .pipe(
                map((data: any) => {
                    sessionStorage.setItem('token', data.token);
                    sessionStorage.setItem('userName', creds.username);
                    return true;
                }));
    }

    register(creds): Observable<boolean> {
        return this.http
            .post("/Account/Register", creds)
            .pipe(
                map((data: any) => {
                    sessionStorage.setItem('token', data.token);
                    sessionStorage.setItem('userName', creds.username);
                    return true;
                }));
    }

    logOut() {
        sessionStorage.removeItem("token");
        sessionStorage.removeItem('userName');
    }
}