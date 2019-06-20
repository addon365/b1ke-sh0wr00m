import { Injectable } from "@angular/core";
import { AppContants } from "../utils/AppContants";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Employee } from "../models/employee";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class EmployeeService {
  URL: string = AppContants.BASE_URL;
  CONTROLLER: string = "Employees";

  constructor(private httpClient: HttpClient) {}

  getEmployees(): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(this.URL + this.CONTROLLER);
  }
  postEmployees(file) {
    var url = this.URL + this.CONTROLLER + "/excel";
    console.log(url);
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
}
