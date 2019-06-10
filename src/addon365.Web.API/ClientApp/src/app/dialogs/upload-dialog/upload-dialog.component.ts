import { Component, OnInit } from "@angular/core";
import { CustomerService } from "src/app/services/customer.service";
import { MatDialogRef } from "@angular/material/dialog";
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: "app-upload-dialog",
  templateUrl: "./upload-dialog.component.html",
  styleUrls: ["./upload-dialog.component.css"]
})
export class UploadDialogComponent implements OnInit {
  constructor(
    private customerService: CustomerService,
    private dialogRef: MatDialogRef<UploadDialogComponent>
  ) {}

  ngOnInit() {}

  fileChange(event) {
    let fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      let file: File = fileList[0];

      this.customerService.postCustomers(file).subscribe(
        data => this.dialogRef.close(data),
        error => this.dialogRef.close(error)
      );
    }
  }
}
