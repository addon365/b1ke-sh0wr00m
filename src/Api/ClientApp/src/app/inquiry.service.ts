import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppContants } from './utils/AppContants';
import { KeyValuePair } from './models/keyvaluepair';



@Injectable({
  providedIn: 'root'
})
export class InquiryService {
  URL: string = AppContants.BASE_URL + "InquiryReport/basedOnProduct";

  constructor(private httpClient: HttpClient) { }

  getInquirieReport(): Observable<KeyValuePair[]> {
    return this.httpClient.get<KeyValuePair[]>(this.URL);
  }
}
