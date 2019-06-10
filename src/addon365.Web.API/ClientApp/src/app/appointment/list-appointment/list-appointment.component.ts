import { Component, OnInit } from "@angular/core";
import { AppointmentService } from "src/app/services/appointment.service";
import { Appointment } from "src/app/models/appointment";

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
    "assignedTo",
    "comments"
  ];
  dataSource: Array<Appointment>;
  constructor(private appointmentService: AppointmentService) {}
  ngOnInit() {
    this.appointmentService.getAllAppointments().subscribe(appointments => {
      this.dataSource = appointments;
    });
  }
}
