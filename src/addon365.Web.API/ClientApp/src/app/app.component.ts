import { Component } from "@angular/core";
import { User } from "./models/user";
import { Login } from "./models/login";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent {
  user: User;
  title = "Bike Show Room";
  isActiveSession: boolean;

  AppComponent() {}
  ngOnInit(): void {
    var userJson = localStorage.getItem("user");
    if (userJson == null) this.isActiveSession = false;
    else {
      this.user = JSON.parse(userJson);
      this.isActiveSession = true;
    }
    console.log(this.isActiveSession);
  }
  loggedIn(currentUser: User) {
    this.user = currentUser;
    this.isActiveSession = true;
  }
  logout() {
    localStorage.removeItem("user");
    this.user = null;
    this.isActiveSession = false;
  }
}
