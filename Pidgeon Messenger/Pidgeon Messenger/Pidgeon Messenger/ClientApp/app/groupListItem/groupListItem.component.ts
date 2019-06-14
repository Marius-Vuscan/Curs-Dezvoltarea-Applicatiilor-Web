import { Component,Input } from '@angular/core';

@Component({
    selector: 'groupListItem',
    templateUrl: "./groupListItem.component.html",
    styles: []
})
export class GroupListItemComponent {
    @Input() groupName: string | null = null;
    @Input() groupId: string | null = null;
}
