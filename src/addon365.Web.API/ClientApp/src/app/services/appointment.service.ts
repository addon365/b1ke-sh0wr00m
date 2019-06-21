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

  getAspDate(date: Date): string {
    var dateAsString =
      date.getMonth() + "/" + date.getDate() + "/" + date.getFullYear();
    return dateAsString;
  }
  postAppointment(appointment: Appointment): Observable<Object> {
    var date = appointment.appointmentDate;
    var dateAsString = this.getAspDate(date);

    var dueDateAsString = this.getAspDate(appointment.currentStatus.dueDate);

    var appointmentJson = {
      LeadId: appointment.lead.id,
      AppointmentDate: dateAsString,
      CurrentStatus: {
        StatusId: appointment.currentStatus.status.id,
        Comments: appointment.currentStatus.comments,
        UpdatedDate: dateAsString,
        UpdatedById: appointment.currentStatus.updatedById,
        AssignedToId: appointment.currentStatus.assignedTo.user.id,
        DueDate: dueDateAsString
      }
    };

    return this.httpClient.post(this.URL + "Appointments", appointmentJson);
  }
  getAllAppointments() {
    return this.httpClient.get<Array<Appointment>>(this.URL + "Appointments");
  }

  findByStatus(statusId: string) {
    if (statusId == null) return this.getAllAppointments();
  
    return this.httpClient.get<Array<Appointment>>(
      this.URL + "Appointments/status",
      {
        params: {
          "statusId":statusId
        }
      }
    );
  }
}
