import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { DashboardComponent } from "./dashboard/dashboard/dashboard.component";
import { LoginComponent } from "./user/login/login.component";
import { ChangePasswordComponent } from "./user/change-password/change-password.component";
import { ListAppointmentComponent } from "./appointment/list-appointment/list-appointment.component";
import { CreateAppointmentComponent } from "./appointment/create-appointment/create-appointment.component";
const routes: Routes = [
  { path: "", redirectTo: "list-appointment", pathMatch: "full" },
  { path: "dashboard", component: DashboardComponent, pathMatch: "full" },
  { path: "change-password", component: ChangePasswordComponent },
  { path: "login", component: LoginComponent },
  { path: "list-appointment", component: ListAppointmentComponent, pathMatch: "full" },
  { path: "create-appointment", component: CreateAppointmentComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
