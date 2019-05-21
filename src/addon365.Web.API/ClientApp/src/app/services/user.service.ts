import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AppContants } from '../utils/AppContants';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { Employee } from '../models/employee';
import { Customer } from '../models/customer';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  URL: string = AppContants.BASE_URL;
  constructor(private httpClient: HttpClient) { }
  getEmployees():Observable<Employee[]>{
    return this.httpClient.get<Employee[]>(this.URL+"employees");
  }
  getCustomers():Observable<Customer[]>{
    return this.httpClient.get<Customer[]>(this.URL+"BusinessCustomers");
  }

}
