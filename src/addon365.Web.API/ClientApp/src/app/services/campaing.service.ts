import { Injectable } from "@angular/core";
import { AppContants } from "../utils/AppContants";
import { HttpClient } from "@angular/common/http";
import { Campaign } from "../models/campaign";
import { Observable } from "rxjs";
import { CampaignViewModel } from "../models/view-model/campaign-view-model";

@Injectable({
  providedIn: "root"
})
export class CampaingService {
  URL: string = AppContants.BASE_URL;

  constructor(private httpClient: HttpClient) {}

  save(campaign: Campaign): Observable<Array<Campaign>> {
    return this.httpClient.post<Array<Campaign>>(this.URL + "campaign", [
      campaign
    ]);
  }

  getCampaigns(): Observable<Array<CampaignViewModel>> {
    return this.httpClient.get<Array<CampaignViewModel>>(this.URL + "campaign/listvm");
  }
}
