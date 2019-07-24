import { Component, OnInit } from "@angular/core";
import { LeadService } from "src/app/services/lead.service";
import { MatDialog, MatDialogConfig } from "@angular/material/dialog";
import { Lead } from "src/app/models/lead";
import { ToastrService } from "ngx-toastr";
import { AppContants } from "src/app/utils/AppContants";
import { UploadDialogComponent } from "src/app/dialogs/upload-dialog/upload-dialog.component";
import { HttpErrorResponse } from "@angular/common/http";

@Component({
  selector: "app-list-lead",
  templateUrl: "./list-lead.component.html",
  styleUrls: ["./list-lead.component.css"]
})
export class ListLeadComponent implements OnInit {
  displcayedColumns: string[] = [
    "businessName",
    "mobileNumber",
    "localityOrVillage",
    "subDistrict"
  ];
  dataSource: Array<Lead>;
  constructor(
    private leadService: LeadService,
    private dialog: MatDialog,
    private toastr: ToastrService
  ) {}
  ngOnInit() {
    this.leadService.getLeads().subscribe(leads => {
      this.dataSource = leads;
    });
  }
  downloadTemplate() {
    var location = this.leadService.getTemplateUrl();
    console.log(location);
    window.location.href = location;
  }

  openDialog() {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.data = { serviceName: "Lead" };

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
