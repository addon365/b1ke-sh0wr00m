import { Component, OnInit } from "@angular/core";
import { Customer } from "src/app/models/customer";
import { CustomerService } from "src/app/services/customer.service";
import { AppContants } from "src/app/utils/AppContants";
import { MatDialogConfig, MatDialog } from "@angular/material/dialog";
import { UploadDialogComponent } from "src/app/dialogs/upload-dialog/upload-dialog.component";
import { ToastrService } from "ngx-toastr";
import { HttpResponse, HttpErrorResponse } from "@angular/common/http";
@Component({
  selector: "app-list-customer",
  templateUrl: "./list-customer.component.html",
  styleUrls: ["./list-customer.component.css"]
})
export class ListCustomerComponent implements OnInit {
  displcayedColumns: string[] = [
    "customerName",
    "businessName",
    "mobileNumber",
    "localityOrVillage",
    "subDistrict"
  ];
  dataSource: Array<Customer>;
  constructor(
    private customerService: CustomerService,
    private dialog: MatDialog,
    private toastr: ToastrService
  ) {}
  ngOnInit() {
    this.customerService.getCustomers().subscribe(customers => {
      this.dataSource = customers;
    });
  }
  downloadTemplate() {
    var t = AppContants.BASE_URL + "BusinessCustomers/template";

    window.location.href = t;
  }

  openDialog() {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.data = { serviceName: "customer" };
    this.dialog
      .open(UploadDialogComponent, dialogConfig)
      .afterClosed()
      .subscribe(
        (data: string) => {
          if (data != null) this.toastr.success(data);
        },
        (error: HttpErrorResponse) => {
          this.toastr.error(error.message);
          console.log(error);
        }
      );
  }
}
