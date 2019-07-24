import { Injectable } from "@angular/core";
import { AppContants } from "../../utils/AppContants";

import { StateMaster } from "../../models/StateMaster";
import { Observable } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { state } from "@angular/animations";

@Injectable({
  providedIn: "root"
})
export class stateMasterService {
  URL: string = AppContants.BASE_URL;
  CONTROLLER: string = "StateMasters";

  constructor(private httpClient: HttpClient) {}




 

  postState(stateMaster: StateMaster) {
    
   
    var url = this.URL + this.CONTROLLER;
    return this.httpClient.post(url,[stateMaster]);
  }
}
