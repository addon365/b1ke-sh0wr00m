import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppContants } from './utils/AppContants';
import { KeyValuePair } from './models/keyvaluepair';
import { InquiryReport } from './models/inquiry-report';



@Injectable({
  providedIn: 'root'
})
export class InquiryService {
  URL: string = AppContants.BASE_URL + "InquiryReport";

  constructor(private httpClient: HttpClient) { }

  get(reportType: string): Observable<InquiryReport[]> {
    var params: HttpParams = new HttpParams({ fromObject: {"reportType":reportType}});
    return this.httpClient.get<InquiryReport[]>(this.URL,
      { params: params });
  }

}
