import { Component, OnInit } from "@angular/core";
import { AppointmentService } from "src/app/services/appointment.service";
import { Appointment } from "src/app/models/appointment";
import { AppointmentViewModel } from "src/app/models/view-model/appointment-view-model";

@Component({
  selector: "app-list-appointment",
  templateUrl: "./list-appointment.component.html",
  styleUrls: ["./list-appointment.component.css"]
})
export class ListAppointmentComponent implements OnInit {
  displayedColumns: string[] = [
    "customerName",
    "appointmentDate",
    "status",
    "dueDate",
    "assignedTo",
    "comments"
  ];
  filterStatus: StatusMaster;
  statuses: Array<StatusMaster>;
  dataSource: Array<AppointmentViewModel>;

  constructor(private appointmentService: AppointmentService) {}

  /**
   * Update Open status for new appointment
   */
  updateStatus() {
    this.appointmentService.getStatuses().subscribe(statuses => {
      this.statuses = statuses;
    });
  }
  updateAllAppointment() {
    this.appointmentService.getAllAppointments().subscribe(appointments => {
      this.dataSource = appointments;
    });
  }
  ngOnInit() {
    this.updateStatus();
    this.updateAllAppointment();
  }
  filter() {
    if (this.filterStatus == null) return;
    this.appointmentService
      .findByStatus(this.filterStatus.id)
      .subscribe(appointments => {
        this.dataSource = appointments;
        console.log(appointments);
      });
  }
  clearFilter() {
    this.filterStatus = null;
    this.appointmentService.getAllAppointments().subscribe(appointments => {
      this.dataSource = appointments;
    });
  }
}
