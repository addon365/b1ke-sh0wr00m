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
    "dueDate",
    "assignedTo",
    "comments"
  ];
  dataSource: Array<Appointment>;
  constructor(private appointmentService: AppointmentService) {}
  ngOnInit() {
    this.appointmentService.getAllAppointments().subscribe(appointments => {
      this.dataSource = appointments;
      console.log(appointments[0]);
      console.log(appointments[0].appointmentDate);
    });
  }
}
