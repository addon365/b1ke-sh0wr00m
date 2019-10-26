import { Component, OnInit, EventEmitter, Output } from "@angular/core";
import { Login } from "../../models/login";
import { UserService } from "src/app/services/user.service";
import { User } from "src/app/models/user";
import { Toast, ToastrService } from "ngx-toastr";
import { Router } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
  user: Login;
  showSpinner: boolean;

  constructor(
    private userService: UserService,
    private toastr: ToastrService,
    private router: Router
  ) {
    this.showSpinner = false;
    this.user = new Login();
  }

  ngOnInit() {
    this.user = new Login();
  }

  login() {
    this.showSpinner = true;
    this.userService
      .validateUser(this.user.userId, this.user.password)
      .subscribe(data => {
        this.showSpinner = false;
        if (data == null) {
          this.toastr.error("User Id/Passowd not match");
          return;
        }
        this.userService.saveSession(data);
        this.router.navigate(["/home"]);
      });
  }
}
