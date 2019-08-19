import { CampaignInfo } from "./campaign-info";

export class Campaign{
    id:string;
    name:string;
    description:string;
    filter:string;
    infos:Array<CampaignInfo>;

}