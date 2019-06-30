import { Component, OnInit } from "@angular/core";
import { LeadService } from "src/app/services/lead.service";
import { LeadSource } from "src/app/models/lead-source";
import { Lead } from "src/app/models/lead";
import { BusinessContact } from "src/app/models/business-contact";
import { Contact } from "src/app/models/contact";
import { AddressMaster } from "src/app/models/address-master";
import { Router } from "@angular/router";

@Component({
  selector: "app-create-lead",
  templateUrl: "./create-lead.component.html",
  styleUrls: ["./create-lead.component.css"]
})
export class CreateLeadComponent implements OnInit {
  lead:Lead;

  leadSource: Array<LeadSource>;
  constructor(private leadService: LeadService,private router: Router) {}

  ngOnInit() {
    this.lead=new Lead();
    this.lead.contact=new BusinessContact();
    this.lead.contact.contactAddress=new AddressMaster();
    
    this.lead.contact.contactPerson=new Contact();
    this.lead.contact.propreitor=new Contact();
    this.leadService.getLeadSources().subscribe(x => {
      this.leadSource = x;
    });
  }
  onSave(){
    console.log(this.lead);
    this.leadService.postLead(this.lead)
    .subscribe(x=>{
      console.log(x);
      this.router.navigate(["/list-lead"]);
    });
  }
}
