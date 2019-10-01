import { AppointmentStatus } from "./appointment-status";
import { Lead } from "./lead";


export class Appointment {
  id: string;
  lead: Lead;
  appointmentDate: Date;
  currentStatus: AppointmentStatus;
}