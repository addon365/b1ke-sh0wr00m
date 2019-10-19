import { Component, OnInit, EventEmitter, Output } from "@angular/core";
import { Login } from "../../models/login";
import { UserService } from "src/app/services/user.service";
import { User } from "src/app/models/user";
import { Toast, ToastrService } from "ngx-toastr";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
  user: Login;
  showSpinner: boolean;
  @Output() afterLogged = new EventEmitter<User>();
  constructor(private userService: UserService, private toastr: ToastrService) {
    this.showSpinner = false;
    this.user = new Login();
  }

  ngOnInit() {
    this.user = new Login();
  }

  login() {
    this.userService
      .validateUser(this.user.userId, this.user.password)
      .subscribe(data => {
        console.log(data);
        if (data == null) {
          this.toastr.error("User Id/Passowd not match");
        } else {
          if (data.roleGroup.name.localeCompare("admin") != 0) {
            this.toastr.error("You need admin Privilage to view this app.");
            return;
          }
          UserService.CurrentUser = data;
          var userJson: string = JSON.stringify(data);
          localStorage.setItem("user", userJson);
          this.afterLogged.emit(data);
        }
      });
  }
}
