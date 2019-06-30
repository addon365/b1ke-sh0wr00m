import { User } from "./user";
import { BusinessContact } from "./business-contact";
import { LeadSource } from "./lead-source";


export class Lead{
    id: string;
    sourceId:string;
    contact: BusinessContact;
    source:LeadSource;
}