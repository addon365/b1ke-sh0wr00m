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
  }
}
