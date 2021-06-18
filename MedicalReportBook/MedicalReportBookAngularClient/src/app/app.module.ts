import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { LandingComponent } from './landing/landing.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginService } from './login.service';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RouterModule } from '@angular/router';
import { PconsultancyReportComponent } from './pconsultancy-report/pconsultancy-report.component';
import { AuthService } from './Services/auth.service';
import { PtestReportComponent } from './ptest-report/ptest-report.component';
import { AddpconsultancyReportComponent } from './addpconsultancy-report/addpconsultancy-report.component';
import { AddtestReportComponent } from './addtest-report/addtest-report.component';
import { DregisterComponent } from './dregister/dregister.component';
import { DoctorConsultancyreportComponent } from './doctor-consultancyreport/doctor-consultancyreport.component';
import { DoctorTestreportComponent } from './doctor-testreport/doctor-testreport.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    LandingComponent,
    DashboardComponent,
    PconsultancyReportComponent,
    PtestReportComponent,
    AddpconsultancyReportComponent,
    AddtestReportComponent,
    DregisterComponent,
    DoctorConsultancyreportComponent,
    DoctorTestreportComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule

  ],
  providers: [AuthService],
  bootstrap:// [DashboardComponent]
                 [AppComponent]
})
export class AppModule { }
