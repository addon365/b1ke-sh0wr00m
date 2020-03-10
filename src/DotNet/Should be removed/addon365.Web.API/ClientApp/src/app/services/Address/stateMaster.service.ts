import { Injectable } from "@angular/core";
import { AppContants } from "../../utils/AppContants";

import { State} from "../../models/Address/State";
import { Observable } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";


@Injectable({
  providedIn: "root"
})
export class stateMasterService {
  URL: string = AppContants.BASE_URL;
  CONTROLLER: string = "master/state";

  constructor(private httpClient: HttpClient) {}




  getStates(): Observable<State[]> {
    return this.httpClient.get<State[]>(this.URL + this.CONTROLLER +"/all");
  }

  postState(stateMaster: State) {
    
   
    var url = this.URL + this.CONTROLLER;
    return this.httpClient.post(url,stateMaster);
  }
}
