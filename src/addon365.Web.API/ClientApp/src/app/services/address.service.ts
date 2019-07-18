import { Injectable } from "@angular/core";
import { AppContants } from "../utils/AppContants";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { SubDistrict } from "../models/address/sub-district";
import { District } from "../models/address/district";
import { Locality } from "../models/address/locality";
import { Pincode } from "../models/address/pincode";

@Injectable({
  providedIn: "root"
})
export class AddressService {
  URL: string = AppContants.BASE_URL;

  constructor(private httpClient: HttpClient) {}

  getDistricts(): Observable<Array<District>> {
    return this.httpClient.get<Array<District>>(this.URL + "address/districts");
  }

  getSubDistricts(): Observable<Array<SubDistrict>> {
    return this.httpClient.get<Array<SubDistrict>>(
      this.URL + "address/subdistricts"
    );
  }

  getLocalities(): Observable<Array<Locality>> {
    return this.httpClient.get<Array<Locality>>(
      this.URL + "address/localities"
    );
  }

  getPincodes(): Observable<Array<Pincode>> {
    return this.httpClient.get<Array<Pincode>>(this.URL + "address/pincodes");
  }
}
