import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { UploadDialogComponent } from 'src/app/dialogs/upload-dialog/upload-dialog.component';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-list-employee',
  templateUrl: './list-employee.component.html',
  styleUrls: ['./list-employee.component.css']
})
export class ListEmployeeComponent implements OnInit {
  displcayedColumns: string[] = [
    "employeeName",
    "role",
    "mobileNumber",
    "localityOrVillage",
    "subDistrict"
  ];
  dataSource: Array<Employee>;
  constructor(
    private employeeService: EmployeeService,
    private dialog: MatDialog,
    private toastr: ToastrService
  ) {}
  ngOnInit() {
    this.employeeService.getEmployees().subscribe(employees => {
      this.dataSource = employees;
    });
  }
  downloadTemplate() {
    var location = this.employeeService.getTemplateUrl();
    console.log(location);
    window.location.href = location;
  }

  openDialog() {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.data = { serviceName: "Employee" };

    this.dialog
      .open(UploadDialogComponent, dialogConfig)
      .afterClosed()
      .subscribe(
        (data: string) => {
          if(data!=null){
            this.toastr.success(data);
          }
          
        },
        (error: HttpErrorResponse) => {
          this.toastr.error(error.message);
          console.log(error);
        }
      );
  }
}
