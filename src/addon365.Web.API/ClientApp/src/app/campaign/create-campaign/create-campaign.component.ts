import { Component, OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { startWith, map } from "rxjs/operators";
import { Campaign } from "src/app/models/campaign";
import { AddressService } from "src/app/services/address.service";
import { SubDistrict } from "src/app/models/address/sub-district";
import { Globals } from "src/app/global";
import { Toast } from "ngx-toastr";
import { CampaingService } from "src/app/services/campaing.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-create-campaign",
  templateUrl: "./create-campaign.component.html",
  styleUrls: ["./create-campaign.component.css"]
})
export class CreateCampaignComponent implements OnInit {
  campaign: Campaign;
  subDistrictControl = new FormControl();
  myControl = new FormControl();
  options: string[] = ["One", "Two", "Three"];
  filteredOptions: Observable<string[]>;
  errorMessage: string;
  constructor(
    private addressService: AddressService,
    private campaignService: CampaingService,
    private globals: Globals,
    private router: Router
  ) {}

  ngOnInit() {
    this.campaign = new Campaign();
   
    this.initAddress();
  }

  filteredSubDistricts: Observable<SubDistrict[]>;

  private _filterSubDistrict(value: string): SubDistrict[] {
    const filterValue = value;

    return this.globals.subDistricts.filter(
      option => option.subDistrictName.toLowerCase().indexOf(filterValue) === 0
    );
  }

  initAddress() {
    if (this.globals.subDistricts == null) {
      this.addressService.getSubDistricts().subscribe(result => {
        this.globals.subDistricts = result;
        this.initSubDistrictFilter();
      });
    } else {
      this.initSubDistrictFilter();
    }
  }
  onSubDistrictSelectionChanged(event) {
    var subDistrict: SubDistrict = event.option.value;
    this.campaign.filter = subDistrict.id;
  }

  displaySubDistrict(district: SubDistrict): string {
    return district ? district.subDistrictName : null;
  }

  initSubDistrictFilter() {
    this.filteredSubDistricts = this.subDistrictControl.valueChanges.pipe(
      startWith(""),
      map(value => this._filterSubDistrict(value))
    );
  }
  validate(): string {
    if (this.campaign.filter == undefined || this.campaign.filter.length == 0)
      return "Select sub district";
    if (this.campaign.name == undefined || this.campaign.filter.length == 0)
      return "Campaign name can't empty";
    return null;
  }

  onSave() {
    this.errorMessage = null;
    this.errorMessage = this.validate();

    if (this.errorMessage == null) {
      this.campaignService.save(this.campaign).subscribe(x => {
        if (x.length > 0) {
          this.router.navigate(["/list-campaign"]);
        }
      });
    }
  }
}
