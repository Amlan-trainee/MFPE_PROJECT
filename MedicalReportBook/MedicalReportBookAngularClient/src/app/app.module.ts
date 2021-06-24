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
import { DeletetestreportComponent } from './deletetestreport/deletetestreport.component';
import { FooterComponent } from './footer/footer.component';
import { Login2Component } from './login2/login2.component';
import { Register2Component } from './register2/register2.component';
import { DeleteDoctorComponent } from './delete-doctor/delete-doctor.component';
import { DeleteConsultancyReportComponent } from './delete-consultancy-report/delete-consultancy-report.component';
import { FeaturesComponent } from './features/features.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { ExtraUserDetailsComponent } from './extra-user-details/extra-user-details.component';
import { ExtraDoctorDetailsComponent } from './extra-doctor-details/extra-doctor-details.component';
import { DoctorPasswordUpdateComponent } from './doctor-password-update/doctor-password-update.component';
import { ToggleStatusComponent } from './toggle-status/toggle-status.component';
import { ToggleTestStatusComponent } from './toggle-test-status/toggle-test-status.component';

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
    DoctorTestreportComponent,
    DeletetestreportComponent,
    FooterComponent,
    Login2Component,
    Register2Component,
    DeleteDoctorComponent,
    DeleteConsultancyReportComponent,
    FeaturesComponent,
    AboutUsComponent,
    ExtraUserDetailsComponent,
    ExtraDoctorDetailsComponent,
    DoctorPasswordUpdateComponent,
    ToggleStatusComponent,
    ToggleTestStatusComponent
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
