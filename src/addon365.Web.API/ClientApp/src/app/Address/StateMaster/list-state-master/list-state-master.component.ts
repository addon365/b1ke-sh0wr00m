import { Component, OnInit } from '@angular/core';
import { State } from '../../../models/address/state';
import { stateMasterService } from "src/app/services/Address/stateMaster.service";
import { MatDialog, MatDialogConfig } from "@angular/material/dialog";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: 'app-list-state-master',
  templateUrl: './list-state-master.component.html',
  styleUrls: ['./list-state-master.component.css']
})
export class ListStateMasterComponent implements OnInit {

  displayedColumns: string[] = [
    "stateName",
   
  ];
  dataSource: Array<State>;
  constructor(private stateService: stateMasterService,
    private dialog: MatDialog,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.stateService.getStates().subscribe(states => {
      this.dataSource = states;
    });
  }

}
