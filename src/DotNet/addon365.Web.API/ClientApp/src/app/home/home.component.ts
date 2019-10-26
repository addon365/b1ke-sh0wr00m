import { Component, OnInit } from "@angular/core";
import { User } from "../models/user";
import { UserService } from "../services/user.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"]
})
export class HomeComponent implements OnInit {
  user: User;
  title = "Bike Show Room";
  
  constructor(private userService: UserService, private router: Router) {}

  ngOnInit() {
    this.user=UserService.CurrentUser;
    console.log(this.user);
  }

  logout() {
    this.userService.clearSession();
    this.router.navigate(["/login"]);

    this.user = null;
  }
}
