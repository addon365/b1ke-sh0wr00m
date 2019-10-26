import { Injectable } from "@angular/core";
import { HttpClient, HttpParams, HttpHeaders } from "@angular/common/http";
import { AppContants } from "../utils/AppContants";
import { Observable } from "rxjs";
import { User } from "../models/user";
import { Employee } from "../models/employee";
import { Customer } from "../models/customer";
@Injectable({
  providedIn: "root"
})
export class UserService {
  static CurrentUser: User;
  URL: string = AppContants.BASE_URL;
  constructor(private httpClient: HttpClient) {}
  getEmployees(): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(this.URL + "employees");
  }
  getCustomers(): Observable<Customer[]> {
    return this.httpClient.get<Customer[]>(this.URL + "BusinessCustomers");
  }
  isAuthenticated() {
    const userJson = localStorage.getItem("user");
    if (userJson == null) {
      return false;
    }

    UserService.CurrentUser = JSON.parse(userJson);
    console.log('lllllllllllllllllllllll', UserService.CurrentUser);
    return true;
  }
  clearSession() {
    localStorage.removeItem("user");
  }
  saveSession(data: User) {
    const userJson: string = JSON.stringify(data);
    UserService.CurrentUser = data;
    localStorage.setItem("user", userJson);
  }
  validateUser(userId: string, password: string): Observable<User> {
    let body = new URLSearchParams();
    body.set("userId", userId);
    body.set("password", password);

    let options = {
      headers: new HttpHeaders().set(
        "Content-Type",
        "application/x-www-form-urlencoded"
      )
    };

    return this.httpClient.post<User>(
      this.URL + "User/authenticate",
      body.toString(),
      options
    );
  }
}
