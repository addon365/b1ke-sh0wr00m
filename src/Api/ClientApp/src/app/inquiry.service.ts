import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppContants } from './utils/AppContants';
import { KeyValuePair } from './models/keyvaluepair';
import { InquiredModel } from './models/inquiredmodel';



@Injectable({
  providedIn: 'root'
})
export class InquiryService {
  URL: string = AppContants.BASE_URL + "InquiryReport/basedOnProduct";
  MonthlyInquiredURL: string = AppContants.BASE_URL + "InquiryReport/inquiredMonthly";

  constructor(private httpClient: HttpClient) { }

  getInquirieReport(): Observable<KeyValuePair<number>[]> {
    return this.httpClient.get<KeyValuePair<number>[]>(this.URL);
  }
  getInquirieMonthlyReport(): Observable<KeyValuePair<InquiredModel[]>[]> {
    return this.httpClient.get<KeyValuePair<InquiredModel[]>[]>(this.MonthlyInquiredURL);
  }

}
