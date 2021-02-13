import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { User } from './user';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})

export class AppComponent implements OnInit {
    user: User = new User();
    users: User[];
    total: number = 0;
    active: number = 0;

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadUsers();
    }

    loadUsers() {
        this.dataService.getUsers()
            .subscribe((data: User[]) => this.users = data);
    }

    update(user : User) {
        if (user.id != null) {
            this.dataService.updateUser(user)
                .subscribe(data => this.loadUsers());
        }
    }

    count() {
        this.total = this.users.length;
        this.active = 0;
        this.users.forEach((element) => {
            if (element.active)
                this.active += 1;
        });
    }
}