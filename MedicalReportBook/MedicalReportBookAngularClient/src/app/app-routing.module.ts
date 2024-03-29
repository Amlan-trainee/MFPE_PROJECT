import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './about-us/about-us.component';
import { AddpconsultancyReportComponent } from './addpconsultancy-report/addpconsultancy-report.component';
import { AddtestReportComponent } from './addtest-report/addtest-report.component';
import { AfterLoginComponent } from './after-login/after-login.component';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DeleteConsultancyReportComponent } from './delete-consultancy-report/delete-consultancy-report.component';
import { DeleteDoctorComponent } from './delete-doctor/delete-doctor.component';
import { DeletetestreportComponent } from './deletetestreport/deletetestreport.component';
import { DoctorConsultancyreportComponent } from './doctor-consultancyreport/doctor-consultancyreport.component';
import { DoctorPasswordUpdateComponent } from './doctor-password-update/doctor-password-update.component';
import { DoctorTestreportComponent } from './doctor-testreport/doctor-testreport.component';
import { DregisterComponent } from './dregister/dregister.component';
import { ExtraDoctorDetailsComponent } from './extra-doctor-details/extra-doctor-details.component';
import { ExtraUserDetailsComponent } from './extra-user-details/extra-user-details.component';
import { FeaturesComponent } from './features/features.component';
import { FooterComponent } from './footer/footer.component';
import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { Login2Component } from './login2/login2.component';
import { PconsultancyReportComponent } from './pconsultancy-report/pconsultancy-report.component';
import { PtestReportComponent } from './ptest-report/ptest-report.component';
import { RegisterComponent } from './register/register.component';
import { Register2Component } from './register2/register2.component';
import { ToggleStatusComponent } from './toggle-status/toggle-status.component';
import { ToggleTestStatusComponent } from './toggle-test-status/toggle-test-status.component';
import { ViewDoctorComponent } from './view-doctor/view-doctor.component';

const routes: Routes = [

  {path: 'Dashboard',component: DashboardComponent},
  {path: 'login',component: LoginComponent},
  {path:'register',component: RegisterComponent},
  {path:'Landing',component: LandingComponent},
  {path:'test-report',component:PtestReportComponent},
  // {
  //   path:'logout',
  //   component:LandingComponent
  // },
  {path:'consultancy-report',component:PconsultancyReportComponent},
  {path:'after-login',component:AfterLoginComponent},
  {path: '',redirectTo:'landing-page' ,pathMatch:'full'},
  //{path: '',component:AppComponent ,pathMatch:'full'},
  {path:'landing-page',component:LandingComponent},
  {path:'add-consultancy-report',component:AddpconsultancyReportComponent},
  {path:'add-test-report',component:AddtestReportComponent},
  {path:'dregister',component:DregisterComponent},
  {path:'doctor-view-consultancy-report',component:DoctorConsultancyreportComponent},
  {path:'doctor-view-test-report',component:DoctorTestreportComponent},
  {path:'footer',component:FooterComponent},
  {path:'login2',component:Login2Component},
  {path:'register2',component:Register2Component},
  {path:'delete-test-report/:Test-Name/:Lr-Id',component:DeletetestreportComponent},
  {path:'delete-doctor/:mail-id/:user-id',component:DeleteDoctorComponent},
  {path:'delete-consultancy-report/:Disease-Name/:CR-Id',component:DeleteConsultancyReportComponent},
  {path:'features',component:FeaturesComponent},
  {path:'about-us',component:AboutUsComponent},
  {path:'extra-user-details',component:ExtraUserDetailsComponent},
  {path:'extra-doctor-details',component:ExtraDoctorDetailsComponent},
  {path:'Update-doctor-password',component:DoctorPasswordUpdateComponent},
  {path:'toggle-status/:R-Id',component:ToggleStatusComponent},
  {path:'toggle-test-status/:R-Id',component:ToggleTestStatusComponent},
  {path:'view-doctor',component:ViewDoctorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
