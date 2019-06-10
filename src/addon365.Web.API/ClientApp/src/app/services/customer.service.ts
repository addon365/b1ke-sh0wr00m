import { Injectable } from "@angular/core";
import { Customer } from "../models/customer";
import { AppContants } from "../utils/AppContants";
import { HttpClient } from "@angular/common/http";
import { HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class CustomerService {
  URL: string = AppContants.BASE_URL;
  CONTROLLER: string = "BusinessCustomers";

  constructor(private httpClient: HttpClient) {}

  getCustomers(): Observable<Customer[]> {
    return this.httpClient.get<Customer[]>(this.URL + this.CONTROLLER);
  }
  postCustomers(file) {
    var url = this.URL + this.CONTROLLER + "/excel";
    let formData: FormData = new FormData();
    formData.append("file", file, file.name);

    let headers = new HttpHeaders().append(
      "Content-Disposition",
      "multipart/form-data"
    );


    return this.httpClient.post(`${url}`, formData, { headers });
  }
}
