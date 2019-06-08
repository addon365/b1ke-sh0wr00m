import { Component, OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Customer } from "src/app/models/customer";
import { Appointment } from "src/app/models/appointment";
import { AppointmentStatus } from "src/app/models/appointment-status";
import { UserService } from "src/app/services/user.service";

import { Employee } from "src/app/models/employee";
import { Observable } from "rxjs";
import { map, startWith } from "rxjs/operators";
import { AppointmentService } from "src/app/services/appointment.service";
import { Router } from "@angular/router";
@Component({
  selector: "app-create-appointment",
  templateUrl: "./create-appointment.component.html",
  styleUrls: ["./create-appointment.component.css"]
})
export class CreateAppointmentComponent implements OnInit {
  customerControl = new FormControl();
  filteredCustomers: Observable<Customer[]>;
  employees: Employee[];
  customers: Customer[];
  appointment: Appointment;

  constructor(
    private userService: UserService,
    private appointmentService: AppointmentService,
    private router: Router
  ) {}
  
  /**
   * Update Open status for new appointment
   */
  updateStatus() {
    this.appointmentService.getStatuses().subscribe(statuses => {
      statuses.forEach(status => {
        if (status.statusName == "Open") {
          this.appointment.currentStatus.status = status;
          return;
        }
      });
    });
  }
  ngOnInit() {
    this.appointment = new Appointment();
    this.appointment.currentStatus = new AppointmentStatus();
    this.updateStatus();
    this.userService.getEmployees().subscribe(employees => {
      this.employees = employees;
    });
    this.userService.getCustomers().subscribe(custs => {
      this.customers = custs;
    });
    this.filteredCustomers = this.customerControl.valueChanges.pipe(
      startWith(""),
      map(customer =>
        customer ? this._filterCustomer(customer) : this.customers.slice(0)
      )
    );
  }
  private _filterCustomer(value: Customer): Customer[] {
    const filterValue = value.user.userName.toLowerCase();

    return this.customers.filter(
      customer =>
        customer.user.userName.toLowerCase().indexOf(filterValue) === 0
    );
  }
  onSave() {
    console.log(this.appointment);
    this.appointmentService
      .postAppointment(this.appointment)
      .subscribe(message => {
        this.router.navigate(["/list-appointment"]);
      });
  }
}
