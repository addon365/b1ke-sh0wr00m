import { Component, OnInit, Inject } from "@angular/core";
import { CustomerService } from "src/app/services/customer.service";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { ToastrService } from "ngx-toastr";
import { LeadService } from "src/app/services/lead.service";
import { EmployeeService } from "src/app/services/employee.service";
@Component({
  selector: "app-upload-dialog",
  templateUrl: "./upload-dialog.component.html",
  styleUrls: ["./upload-dialog.component.css"]
})
export class UploadDialogComponent implements OnInit {
  public serviceName: string;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private customerService: CustomerService,
    private leadService: LeadService,
    private empService: EmployeeService,
    private dialogRef: MatDialogRef<UploadDialogComponent>
  ) {
    this.serviceName = data.serviceName;
  }

  ngOnInit() {}
  close() {
    this.dialogRef.close(null);
  }

  fileChange(event) {
    let fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      let file: File = fileList[0];
      if (this.serviceName.localeCompare("customer") == 0) {
        this.customerService
          .postCustomers(file)
          .subscribe(
            data => this.dialogRef.close(data),
            error => this.dialogRef.close(error)
          );
      } else if (this.serviceName.localeCompare("Lead") == 0) {
        this.leadService
          .postLeads(file)
          .subscribe(
            data => this.dialogRef.close(data),
            error => this.dialogRef.close(error)
          );
      } else {
        this.empService
          .postEmployees(file)
          .subscribe(
            data => this.dialogRef.close(data),
            error => this.dialogRef.close(error)
          );
      }
    }
  }
}
