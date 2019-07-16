import { BusinessContact } from "./business-contact";
import { LeadSource } from "./lead-source";
import { LeadStatusHistory } from "./lead-status-history";

export class Lead {
  id: string;
  sourceId: string;
  contact: BusinessContact;
  
  source: LeadSource;
  history: Array<LeadStatusHistory>;
}
