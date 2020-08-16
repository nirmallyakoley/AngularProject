import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../model/user';



@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    getAll() {
        var userList: User[] = [
            new User(5, "SH12345", "password", "Shankar", "Venkatesh", "User", "User", "shankar.venkatesh@wipro.com"),
            new User(1, "NI393270", "password", "Nirmal", "Kolay", "User", "User", "nirmallya.kolay@wipro.com"),
            new User(2, "SW12345", "password", "Swapnil", "Wagh", "Approver", "PDM", "swapnil.wagh2@wipro.com"),
            new User(3, "JA12345", "password", "Jay", "Yepuri", "Approver", "TAP", "jay.yepuri@wipro.com"),
            new User(4, "HA12345", "password", "Hari", "Pittu", "Approver", "Director", "hari.pittu@wipro.com")
                                ];

        return userList;
    }
}
