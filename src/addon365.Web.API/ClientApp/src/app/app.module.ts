import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AppComponent } from "./app.component";
import { HttpClientModule } from "@angular/common/http";
import { DashboardComponent } from "./dashboard/dashboard/dashboard.component";
import { MatCardModule } from "@angular/material/card";
import { FlexLayoutModule } from "@angular/flex-layout";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatButtonModule } from "@angular/material/button";
import { MatTableModule } from "@angular/material/table";
import { MatIconModule } from "@angular/material/icon";
import { MatMenuModule } from "@angular/material/menu";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatSidenavModule } from "@angular/material/sidenav";
import { LoginComponent } from "./user/login/login.component";
import { MatListModule } from "@angular/material/list";
import { MatFormFieldModule } from "@angular/material/form-field";
import { ChangePasswordComponent } from "./user/change-password/change-password.component";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatInputModule } from "@angular/material/input";
import { MatAutocompleteModule } from "@angular/material/autocomplete";
import { Ng2GoogleChartsModule } from "ng2-google-charts";
import { MatSelectModule } from "@angular/material/select";
import { CreateAppointmentComponent } from "./appointment/create-appointment/create-appointment.component";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { ListAppointmentComponent } from "./appointment/list-appointment/list-appointment.component";
import { MatNativeDateModule } from "@angular/material/core";
import { Routes, RouterModule } from "@angular/router";
import { ListCustomerComponent } from "./customer/list-customer/list-customer.component";
import { MatDialogModule } from "@angular/material/dialog";
import { UploadDialogComponent } from './dialogs/upload-dialog/upload-dialog.component';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { ToastrModule } from 'ngx-toastr';
import { ListLeadComponent } from './lead/list-lead/list-lead.component';
import { ListEmployeeComponent } from './employee/list-employee/list-employee.component';
import { CreateLeadComponent } from './lead/create-lead/create-lead.component';
import { CreateStateMasterComponent } from './Address/StateMaster/create-StateMaster/create-statemaster.component';
const routes: Routes = [
  { path: "", redirectTo: "list-appointment", pathMatch: "full" },
  { path: "dashboard", component: DashboardComponent, pathMatch: "full" },
  { path: "change-password", component: ChangePasswordComponent },
  { path: "login", component: LoginComponent },
  {
    path: "list-appointment",
    component: ListAppointmentComponent,
    pathMatch: "full"
  },
  { path: "create-appointment", component: CreateAppointmentComponent },
  { path: "list-customer", component: ListCustomerComponent },
  { path: "list-lead", component: ListLeadComponent },
  { path: "create-lead", component: CreateLeadComponent },
  { path: "list-employee", component: ListEmployeeComponent },
  { path: "create-state", component: CreateStateMasterComponent },
];
@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    LoginComponent,
    ChangePasswordComponent,
    CreateAppointmentComponent,
    ListAppointmentComponent,
    ListCustomerComponent,
    UploadDialogComponent,
    ListLeadComponent,
    ListEmployeeComponent,
    CreateLeadComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    AngularFontAwesomeModule,
    MatToolbarModule,
    HttpClientModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    MatDialogModule,
    RouterModule.forRoot(routes),
    MatSidenavModule,
    MatListModule,

    MatFormFieldModule,
    MatProgressSpinnerModule,
    MatInputModule,
    Ng2GoogleChartsModule,
    MatSelectModule,
    MatAutocompleteModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatTableModule,
    
  ],
  providers: [MatDatepickerModule],
  bootstrap: [AppComponent],
  entryComponents: [UploadDialogComponent]
})
export class AppModule {}
