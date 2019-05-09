import { AppointmentStatus } from "./appointment-status";

export class Appointment {
  id: string;
  customerId: string;
  appointmentDate: Date;
  appointmentStatuses: Array<AppointmentStatus>;
}