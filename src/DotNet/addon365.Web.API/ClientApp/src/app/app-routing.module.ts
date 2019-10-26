import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { DashboardComponent } from "./dashboard/dashboard/dashboard.component";
import { LoginComponent } from "./user/login/login.component";
import { ChangePasswordComponent } from "./user/change-password/change-password.component";
import { ListAppointmentComponent } from "./appointment/list-appointment/list-appointment.component";
import { CreateAppointmentComponent } from "./appointment/create-appointment/create-appointment.component";
import { HomeComponent } from "./home/home.component";
import { ListCustomerComponent } from "./customer/list-customer/list-customer.component";
import { ListLeadComponent } from "./lead/list-lead/list-lead.component";
import { CreateLeadComponent } from "./lead/create-lead/create-lead.component";
import { ListEmployeeComponent } from "./employee/list-employee/list-employee.component";
import { ListStateMasterComponent } from "./Address/StateMaster/list-state-master/list-state-master.component";
import { CreateStateMasterComponent } from "./Address/StateMaster/create-StateMaster/create-statemaster.component";
import { CreateCampaignComponent } from "./campaign/create-campaign/create-campaign.component";
import { ListCampaignComponent } from "./campaign/list-campaign/list-campaign.component";
import { AuthGuard } from "./guard/auth-guard";
const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "change-password", component: ChangePasswordComponent },
  { path: "", redirectTo: "/home", pathMatch: "full" },
  {
    path: "home",
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      { path: "dashboard", component: DashboardComponent },
      { path: "change-password", component: ChangePasswordComponent },
      {
        path: "list-appointment",
        component: ListAppointmentComponent
      },
      { path: "create-appointment", component: CreateAppointmentComponent },
      { path: "list-customer", component: ListCustomerComponent },
      { path: "list-lead", component: ListLeadComponent },
      { path: "create-lead", component: CreateLeadComponent },
      { path: "list-employee", component: ListEmployeeComponent },
      { path: "list-state", component: ListStateMasterComponent },
      { path: "create-state", component: CreateStateMasterComponent },
      { path: "create-campaign/:id", component: CreateCampaignComponent },
      { path: "list-campaign", component: ListCampaignComponent }
    ]
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
