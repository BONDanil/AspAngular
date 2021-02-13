import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user';

@Injectable()
export class DataService {

    private url = "/api/users";

    constructor(private http: HttpClient) {
    }

    getUsers() {
        return this.http.get(this.url);
    }

    updateUser(user: User) {

        return this.http.put(this.url, user);
    }
}