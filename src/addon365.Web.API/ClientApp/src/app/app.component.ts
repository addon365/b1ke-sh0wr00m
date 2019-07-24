import { Component } from "@angular/core";
import { User } from "./models/user";
import { Login } from "./models/login";
import { AddressService } from "./services/address.service";
import { Globals } from "./global";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent {
  user: User;
  title = "Bike Show Room";
  isActiveSession: boolean;

  constructor(
    private addressSerive: AddressService,
    private globals: Globals
  ) {}

  initAddresses() {
    this.addressSerive.getDistricts().subscribe(result => {
      this.globals.districts = result;
      console.log(this.globals.districts);
    });

    this.addressSerive.getSubDistricts().subscribe(result => {
      this.globals.subDistricts = result;
    });

    this.addressSerive.getLocalities().subscribe(result => {
      this.globals.localities = result;
    });

    this.addressSerive.getPincodes().subscribe(result => {
      this.globals.pincodes = result;
    });
  }

  ngOnInit(): void {
    this.initAddresses();
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
