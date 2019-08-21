import { Lead } from "./lead";
import { LeadStatusHistory } from "./lead-status-history";

export class CampaignInfo{
    leadId:string;
    lead:Lead;
    currentStatusId:string;
    currentStatus:LeadStatusHistory;
    isInProgress:boolean;

}