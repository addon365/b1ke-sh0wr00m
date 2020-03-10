import { Injectable } from "@angular/core";
import { SubDistrict } from "./models/address/sub-district";
import { Locality } from "./models/address/locality";
import { District } from "./models/address/district";
import { Pincode } from "./models/address/pincode";

@Injectable({ providedIn: "root" })
export class Globals {
  subDistricts: Array<SubDistrict>;
  districts: Array<District>;
  localities: Array<Locality>;
  pincodes: Array<Pincode>;
}
