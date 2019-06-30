import { Injectable } from "@angular/core";
import { AppContants } from "../utils/AppContants";

import { Lead } from "../models/lead";
import { Observable } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { LeadSource } from "../models/lead-source";

@Injectable({
  providedIn: "root"
})
export class LeadService {
  URL: string = AppContants.BASE_URL;
  CONTROLLER: string = "Leads";

  constructor(private httpClient: HttpClient) {}

  getLeads(): Observable<Lead[]> {
    return this.httpClient.get<Lead[]>(this.URL + this.CONTROLLER);
  }
  postLeads(file) {
    var url = this.URL + this.CONTROLLER + "/excel";
    let formData: FormData = new FormData();
    formData.append("file", file, file.name);

    let headers = new HttpHeaders().append(
      "Content-Disposition",
      "multipart/form-data"
    );

    return this.httpClient.post(`${url}`, formData, { headers });
  }

  getTemplateUrl() {
    return this.URL + this.CONTROLLER + "/template";
  }

  getLeadSources(): Observable<Array<LeadSource>> {
    var url = this.URL + "LeadSource";
    return this.httpClient.get<Array<LeadSource>>(`${url}`);
  }

  postLead(lead: Lead) {
    lead.sourceId=lead.source.id;
    lead.source=null;
    var url = this.URL + this.CONTROLLER;
    return this.httpClient.post(url,lead);
  }
}
