import { LeadStatusMaster } from "./lead-status-master";

export class LeadStatusHistory {
  statusDate: Date;
  statusId: string;
  status: LeadStatusMaster;
  extraData: string;
  order: number;
}
