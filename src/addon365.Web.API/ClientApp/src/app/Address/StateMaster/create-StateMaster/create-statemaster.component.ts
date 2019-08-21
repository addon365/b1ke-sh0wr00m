import { Component, OnInit } from "@angular/core";
import { stateMasterService } from "src/app/services/Address/stateMaster.service";
import { State} from "src/app/models/Address/State";
import { Router } from "@angular/router";

@Component({
  selector: "app-create-statemaster",
  templateUrl: "./create-statemaster.component.html",
  styleUrls: ["./create-statemaster.component.css"]
})
export class CreateStateMasterComponent implements OnInit {
  StateMaster:State;

 
  constructor(private StateService: stateMasterService,private router: Router) {}

  ngOnInit() {
    this.StateMaster=new State();
  
  }
  onSave(){
    console.log(this.StateMaster);

    this.StateService.postState(this.StateMaster)
    .subscribe(x=>{
      console.log("RESULT:"+x);
      
    });
  }
}
