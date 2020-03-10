import { AddressMaster } from "./address-master";
import { Contact } from "./contact";

export class BusinessContact {
  businessName: string;
  contactAddress: AddressMaster;
  landline: string;
  mobileNumber: string;
  secondaryMobileNumber: string;
  proprietor:Contact;
  contactPerson:Contact;
}
