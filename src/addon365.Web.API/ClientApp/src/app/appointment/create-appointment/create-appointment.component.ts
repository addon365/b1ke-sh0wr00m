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
import { Lead } from "src/app/models/lead";
import { LeadService } from "src/app/services/lead.service";
import { AppointmentViewModel } from "src/app/models/view-model/appointment-view-model";
@Component({
  selector: "app-create-appointment",
  templateUrl: "./create-appointment.component.html",
  styleUrls: ["./create-appointment.component.css"]
})
export class CreateAppointmentComponent implements OnInit {
  customerControl = new FormControl();
  filteredLeads: Observable<Lead[]>;
  employees: Employee[];
  leads: Lead[];
  appointment: AppointmentViewModel;
  selectedLead: Lead;

  constructor(
    private userService: UserService,
    private appointmentService: AppointmentService,
    private leadService: LeadService,
    private router: Router
  ) {}

  /**
   * Update Open status for new appointment
   */
  updateStatus() {
    this.appointmentService.getStatuses().subscribe(statuses => {
      statuses.forEach(status => {
        if (status.statusName == "Open") {
          this.appointment.statusId = status.id;
          return;
        }
      });
    });
  }
  ngOnInit() {
    this.appointment = new AppointmentViewModel();
    
    this.updateStatus();
    this.userService.getEmployees().subscribe(employees => {
      this.employees = employees;
    });
    this.leadService.getLeads().subscribe(leads => {
      this.leads = leads;
    });
    this.filteredLeads = this.customerControl.valueChanges.pipe(
      startWith(""),
      map(customer =>
        customer ? this._filterCustomer(customer) : this.leads.slice(0)
      )
    );
  }
  private _filterCustomer(value: Customer): Customer[] {
    const filterValue = value.user.userName.toLowerCase();

    return this.leads.filter(
      lead => lead.user.userName.toLowerCase().indexOf(filterValue) === 0
    );
  }
  onSave() {
    console.log(this.appointment);
    this.appointment.leadId=this.selectedLead.id;
    this.appointmentService
      .postAppointment(this.appointment)
      .subscribe(message => {
        this.router.navigate(["/list-appointment"]);
      });
  }
}
