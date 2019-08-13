import { Component, OnInit } from "@angular/core";
import { CampaingService } from "src/app/services/campaing.service";

import { Campaign } from "src/app/models/campaign";
import { CampaignViewModel } from "src/app/models/view-model/campaign-view-model";

@Component({
  selector: "app-list-campaign",
  templateUrl: "./list-campaign.component.html",
  styleUrls: ["./list-campaign.component.css"]
})
export class ListCampaignComponent implements OnInit {
  displcayedColumns: string[] = [
    "campaignName",
    "description",
    "filter",
    "count"
  ];
  dataSource: Array<CampaignViewModel>;
  constructor(private campaignService: CampaingService) {}
  ngOnInit() {
    this.campaignService.getCampaigns().subscribe(campaigns => {
      this.dataSource = campaigns;
    });
  }
}
