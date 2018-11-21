import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard/dashboard.component';
import { LoginComponent } from './user/login/login.component';
import { ChangePasswordComponent } from './user/change-password/change-password.component';
const routes: Routes = [
  { path: "dashboard", component: DashboardComponent },
  { path: "change-password", component: ChangePasswordComponent },
  { path: "login", component: LoginComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
