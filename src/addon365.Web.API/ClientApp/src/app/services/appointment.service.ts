import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { AppContants } from "../utils/AppContants";
import { Observable } from "rxjs";
import { AppointmentStatus } from "../models/appointment-status";
import { Appointment } from "../models/appointment";
@Injectable({
  providedIn: "root"
})
export class AppointmentService {
  URL: string = AppContants.BASE_URL;
  static appointmentStatuses: AppointmentStatus[];
  constructor(private httpClient: HttpClient) {}

  getStatuses(): Observable<StatusMaster[]> {
    return this.httpClient.get<StatusMaster[]>(this.URL + "StatusesMaster");
  }

  postAppointment(appointment: Appointment): Observable<Object> {
    var date = appointment.appointmentDate;
    var dateAsString =
      date.getDate() + "-" + date.getMonth() + "-" + date.getFullYear();
    var appointmentJson = {
      CustomerId: appointment.customer.id,
      AppiontmentDate: dateAsString,
      CurrentStatus: {
        StatusId: appointment.currentStatus.status.id,
        Comments: appointment.currentStatus.comments,
        UpdatedDate: new Date(),
        UpdatedById: appointment.currentStatus.updatedById,
        AssignedToId: appointment.currentStatus.assignedTo.user.id
      } 
    };
    console.log("JSON:" + appointmentJson.AppiontmentDate);
    return this.httpClient.post(this.URL + "Appointments", appointmentJson);
  }
  getAllAppointments() {
    return this.httpClient.get<Array<Appointment>>(this.URL + "Appointments");
  }
}
