import { Employee } from "./employee";

export class AppointmentStatus{
    status: StatusMaster;
    comments: string;
    updateDate: Date;
    assignedTo:Employee;
    updatedById:string;
}