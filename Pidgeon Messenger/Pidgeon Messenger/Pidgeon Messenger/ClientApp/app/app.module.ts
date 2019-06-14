import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { DataService } from './shared/dataService';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { Login } from './login/login.component';
import { Register } from './register/register.component';
import { ChatListComponent } from './chatslist/chatList.component';
import { AuthGuard } from './shared/AuthGuard';
import { ChatComponent } from './chat/chat.component';
import { SignalRService } from './shared/signalRService';
import { NavbarComponent } from './navbar/navbar.component';
import { GroupListItemComponent } from './groupListItem/groupListItem.component';
import { MessageComponent } from './message/message.component';

let routes = [
    { path: "", component: HomeComponent },
    { path: "login", component: Login },
    { path: "register", component: Register },
    { path: "chatList", component: ChatListComponent, canActivate: [AuthGuard] },
    { path: "chat/:id", component: ChatComponent, canActivate: [AuthGuard] }
];

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        Login,
        Register,
        ChatListComponent,
        ChatComponent,
        NavbarComponent,
        GroupListItemComponent,
        MessageComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot(routes, {
            useHash: true,
            enableTracing: false
        })
    ],
    providers: [
        DataService,
        AuthGuard,
        SignalRService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
