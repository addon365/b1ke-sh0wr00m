import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { AppContants } from "../utils/AppContants";
import { Observable } from "rxjs";
import { AppointmentStatus } from "../models/appointment-status";
import { Appointment } from "../models/appointment";
import { AppointmentViewModel } from "../models/view-model/appointment-view-model";
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

  getAspDate(date: Date): string {
    var dateAsString =
      date.getMonth() + "/" + date.getDate() + "/" + date.getFullYear();
    return dateAsString;
  }
  postAppointment(appointment: AppointmentViewModel): Observable<Object> {
    var date = appointment.appointmentDate;
    var dateAsString = this.getAspDate(date);

    var dueDateAsString = this.getAspDate(appointment.dueDate);

    var appointmentJson = {
      LeadId: appointment.leadId,
      AppointmentDate: dateAsString,
      CurrentStatus: {
        StatusId: appointment.statusId,
        Comments: appointment.comments,
        UpdatedDate: dateAsString,
        UpdatedById: appointment.updatedById,
        AssignedToId: appointment.assignedToId,
        DueDate: dueDateAsString
      }
    };

    return this.httpClient.post(this.URL + "Appointments", appointment);
  }
  getAllAppointments() {
    return this.httpClient.get<Array<AppointmentViewModel>>(this.URL + "Appointments");
  }

  findByStatus(statusId: string) {
    if (statusId == null) return this.getAllAppointments();
  
    return this.httpClient.get<Array<AppointmentViewModel>>(
      this.URL + "Appointments/status",
      {
        params: {
          "statusId":statusId
        }
      }
    );
  }
}
