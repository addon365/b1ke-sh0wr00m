import { Component, OnInit } from "@angular/core";
import { LeadService } from "src/app/services/lead.service";
import { LeadSource } from "src/app/models/lead-source";
import { Lead } from "src/app/models/lead";
import { BusinessContact } from "src/app/models/business-contact";
import { Contact } from "src/app/models/contact";
import { AddressMaster } from "src/app/models/address-master";
import { Router } from "@angular/router";
import { Globals } from "src/app/global";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { startWith, map } from "rxjs/operators";
import { SubDistrict } from "src/app/models/address/sub-district";
import { Locality } from "src/app/models/address/locality";
import { Pincode } from "src/app/models/address/pincode";
import { AddressService } from "src/app/services/address.service";
import { District } from "src/app/models/address/district";

@Component({
  selector: "app-create-lead",
  templateUrl: "./create-lead.component.html",
  styleUrls: ["./create-lead.component.css"]
})
export class CreateLeadComponent implements OnInit {
  lead: Lead;
  pincodeControl = new FormControl();
  localityControl = new FormControl();
  subDistrictControl = new FormControl();

  leadSource: Array<LeadSource>;
  constructor(
    private leadService: LeadService,
    private router: Router,
    private globals: Globals,
    private addressService: AddressService
  ) {}

  ngOnInit() {
    this.lead = new Lead();
    this.lead.contact = new BusinessContact();
    this.lead.contact.contactAddress = new AddressMaster();

    this.lead.contact.contactPerson = new Contact();
    this.lead.contact.proprietor = new Contact();
    this.leadService.getLeadSources().subscribe(x => {
      this.leadSource = x;
    });

    this.initAddresses();
  }

  onSave() {
    console.log(this.lead);

    this.leadService.postLead(this.lead).subscribe(x => {
      this.router.navigate(["/list-lead"]);
    });
  }

  //#region All the address members and methods goes here

  selectedSubDistrict: SubDistrict;
  filteredSubDistricts: Observable<SubDistrict[]>;

  selectedLocality: Locality;
  filteredLocality: Observable<Locality[]>;

  selectedPincode: Pincode;
  filteredPincodes: Observable<Pincode[]>;

  private _filterSubDistrict(value: string): SubDistrict[] {
    const filterValue = value;

    return this.globals.subDistricts.filter(
      option => option.subDistrictName.toLowerCase().indexOf(filterValue) === 0
    );
  }

  private _filterLocality(value: string): Locality[] {
    const filterValue =
      !value || value == undefined || value == "" ? "" : value;

    return this.globals.localities.filter(
      option =>
        option.localityOrVillageName.toLowerCase().indexOf(filterValue) === 0
    );
  }

  private _filterPincode(value: string): Pincode[] {
    return this.globals.pincodes.filter(
      option => option.pincode.toString().indexOf(value) === 0
    );
  }

  onPincodeSelectionChanged(event) {
    this.lead.contact.contactAddress.pinOrZip = event.option.value;
  }

  onLocalitySelectionChanged(event) {
    var locality: Locality = event.option.value;
    this.lead.contact.contactAddress.localityOrVillage =
      locality.localityOrVillageName;
    this.lead.contact.contactAddress.localityOrVillageId = locality.id;
  }

  onSubDistrictSelectionChanged(event) {
    var subDistrict: SubDistrict = event.option.value;
    this.lead.contact.contactAddress.subDistrict = subDistrict.subDistrictName;
    this.lead.contact.contactAddress.subDistrictId = subDistrict.id;
  }

  displayLocality(locality: Locality): string {
    return locality ? locality.localityOrVillageName : null;
  }

  displaySubDistrict(district: SubDistrict): string {
    return district ? district.subDistrictName : null;
  }
  /**
   * Initializes all the Address Auto complete controls
   */
  initAddresses() {
    if (this.globals.subDistricts == null) {
      this.addressService.getSubDistricts().subscribe(result => {
        this.globals.subDistricts = result;
        this.initSubDistrictFilter();
      });
    } else {
      this.initSubDistrictFilter();
    }

    if (this.globals.localities == null) {
      this.addressService.getLocalities().subscribe(result => {
        this.globals.localities = result;
        this.initLocalityFilter();
      });
    } else {
      this.initLocalityFilter();
    }

    if (this.globals.pincodes == null) {
      this.addressService.getPincodes().subscribe(result => {
        this.globals.pincodes = result;
        this.initPincodeFilter();
      });
    } else {
      this.initPincodeFilter();
    }
  }
  initSubDistrictFilter() {
    this.filteredSubDistricts = this.subDistrictControl.valueChanges.pipe(
      startWith(""),
      map(value => this._filterSubDistrict(value))
    );
  }

  initLocalityFilter() {
    this.filteredLocality = this.localityControl.valueChanges.pipe(
      startWith(""),
      map(value => this._filterLocality(value))
    );
  }

  initPincodeFilter() {
    this.filteredPincodes = this.pincodeControl.valueChanges.pipe(
      startWith(""),
      map(value => this._filterPincode(value))
    );
  }

  //#endregion
}
