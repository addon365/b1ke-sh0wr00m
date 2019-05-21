import { AppointmentStatus } from "./appointment-status";
import { Customer } from "./customer";

export class Appointment {
  id: string;
  customer: Customer;
  appointmentDate: Date;
  currentStatus: AppointmentStatus;
}