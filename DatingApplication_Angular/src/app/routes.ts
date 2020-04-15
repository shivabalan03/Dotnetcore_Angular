import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './member-list/member-list.component';
import { MessageComponent } from './message/message.component';
import { ListsComponent } from './lists/lists.component';

export const AppRoutes: Routes = [
    {path: 'home', component: HomeComponent},
    {path: 'members', component: MemberListComponent},
    {path: 'message', component: MessageComponent},
    {path: 'list', component: ListsComponent},
    {path: '**', redirectTo: 'home', pathMatch: 'full'}
];
