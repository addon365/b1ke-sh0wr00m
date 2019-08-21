import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { startWith, map } from "rxjs/operators";
import { Campaign } from "src/app/models/campaign";
import { AddressService } from "src/app/services/address.service";
import { SubDistrict } from "src/app/models/address/sub-district";
import { Globals } from "src/app/global";
import { Toast } from "ngx-toastr";
import { CampaingService } from "src/app/services/campaing.service";
import { Router, ActivatedRoute } from "@angular/router";
import { COMMA, ENTER } from "@angular/cdk/keycodes";

import {
  MatAutocompleteSelectedEvent,
  MatAutocomplete
} from "@angular/material/autocomplete";
import { MatChipInputEvent } from "@angular/material/chips";

@Component({
  selector: "app-create-campaign",
  templateUrl: "./create-campaign.component.html",
  styleUrls: ["./create-campaign.component.css"]
})
export class CreateCampaignComponent implements OnInit {
  //maintains the component (Edit/Create) state
  isEdit: boolean;
  campaign: Campaign;

  myControl = new FormControl();

  errorMessage: string;

  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  separatorKeysCodes: number[] = [ENTER, COMMA];
  subDistrictCtrl = new FormControl();

  selectedSubDistricts: SubDistrict[] = [];

  @ViewChild("subDistrictInput") subDistrictInput: ElementRef<HTMLInputElement>;
  @ViewChild("auto") matAutocomplete: MatAutocomplete;

  constructor(
    private addressService: AddressService,
    private campaignService: CampaingService,
    private globals: Globals,
    private router: Router,
    private activeRouter: ActivatedRoute
  ) {
    this.initAddress();
  }

  ngOnInit() {
    this.campaign = new Campaign();

    this.activeRouter.paramMap.subscribe(params => {
      this.isEdit = true;
      this.loadCampaign(params.get("id"));
    });
  }
  loadCampaign(id: string) {
    this.campaignService.getCampaign(id).subscribe(result => {
      this.campaign.id = result.id;
      this.campaign.name = result.name;
      this.campaign.description = result.description;
      var filterIds: string[] = result.filter.split(",");
      for (var i = 0; i < filterIds.length; i++) {
        var district = this.globals.subDistricts.find(
          x => x.id == filterIds[i]
        );
        this.selectedSubDistricts.push(district);
      }
    });
  }

  filteredSubDistricts: Observable<SubDistrict[]>;

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
  initSubDistrictFilter() {
    this.filteredSubDistricts = this.subDistrictCtrl.valueChanges.pipe(
      startWith(null),
      map((subDistrictName: string | null) =>
        subDistrictName
          ? this._filter(subDistrictName)
          : this.globals.subDistricts.slice()
      )
    );
  }
  onSubDistrictSelectionChanged(event) {
    var subDistrict: SubDistrict = event.option.value;
    this.campaign.filter = subDistrict.id;
  }

  displaySubDistrict(district: SubDistrict): string {
    return district ? district.subDistrictName : null;
  }

  validate(): string {
    if (this.selectedSubDistricts.length > 0) {
      this.campaign.filter = this.selectedSubDistricts[0].id;
      for (var i = 1; i < this.selectedSubDistricts.length; i++) {
        var selectedSubDistrict = this.selectedSubDistricts[i];
        this.campaign.filter = this.campaign.filter
          .concat(",")
          .concat(selectedSubDistrict.id);
      }
    }

    if (this.campaign.filter == undefined || this.campaign.filter.length == 0)
      return "Select sub district";
    if (this.campaign.name == undefined || this.campaign.filter.length == 0)
      return "Campaign name can't empty";
    return null;
  }

  onSave() {
    this.errorMessage = null;
    this.errorMessage = this.validate();
    if (this.errorMessage != null) return;

    if (this.isEdit) {
      this.edit();
    } else {
      this.save();
    }
  }
  edit() {
    this.campaignService.edit(this.campaign).subscribe(x => {
      console.log(x);
      if (x != null) {
        this.router.navigate(["/list-campaign"]);
      }
    });
  }
  save() {
    this.campaignService.save(this.campaign).subscribe(x => {
      if (x.length > 0) {
        this.router.navigate(["/list-campaign"]);
      }
    });
  }

  //#region Chip Filter
  add(event: MatChipInputEvent): void {
    // Add sub district only when MatAutocomplete is not open
    // To make sure this does not conflict with OptionSelected Event
    if (!this.matAutocomplete.isOpen) {
      const input = event.input;
      const value = event.value;

      // Add our sub district
      if ((value || "").trim()) {
        for (var i = 0; i < this.globals.subDistricts.length; i++) {
          var subDistrict = this.globals.subDistricts[i];
          if (
            subDistrict.subDistrictName
              .toLocaleLowerCase()
              .localeCompare(value.toLocaleLowerCase()) == 0
          ) {
            this.selectedSubDistricts.push(subDistrict);
            break;
          }
        }
      }

      // Reset the input value
      if (input) {
        input.value = "";
      }

      this.subDistrictCtrl.setValue(null);
    }
  }

  remove(subDistrict: SubDistrict): void {
    const index = this.selectedSubDistricts.findIndex(
      x => x.id.localeCompare(subDistrict.id) == 0
    );

    if (index >= 0) {
      this.selectedSubDistricts.splice(index, 1);
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    this.selectedSubDistricts.push(event.option.value);
    this.subDistrictInput.nativeElement.value = "";
    this.subDistrictCtrl.setValue(null);
  }

  private _filter(value: string | SubDistrict): SubDistrict[] {
    if (value instanceof Object) return this.globals.subDistricts.slice();
    var filterValue = value.toLowerCase();
    return this.globals.subDistricts.filter(
      subDistrict =>
        subDistrict.subDistrictName.toLowerCase().indexOf(filterValue) === 0
    );
  }
  //endregion Chip Filter
}
