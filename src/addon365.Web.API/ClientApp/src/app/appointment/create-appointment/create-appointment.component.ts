import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Customer } from 'src/app/models/customer';
import { Appointment } from 'src/app/models/appointment';
import { AppointmentStatus } from 'src/app/models/appointment-status';

@Component({
  selector: 'app-create-appointment',
  templateUrl: './create-appointment.component.html',
  styleUrls: ['./create-appointment.component.css']
})
export class CreateAppointmentComponent implements OnInit {
  myControl = new FormControl();
  customers: Customer[];

  appointment: Appointment;
  statuses: StatusMaster[] = [
    { id: "1", statusName: "Open",description:"Open Status",programmerId: "1393"},
    { id: "2", statusName: "Close", description: "Close Status", programmerId: "1395" },
  ];

  constructor() { }

  ngOnInit() {
    this.appointment=new Appointment();
    this.appointment.appointmentStatuses=new Array<AppointmentStatus>();
  }

}
