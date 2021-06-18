import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddpconsultancyReportComponent } from './addpconsultancy-report/addpconsultancy-report.component';
import { AddtestReportComponent } from './addtest-report/addtest-report.component';
import { AfterLoginComponent } from './after-login/after-login.component';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DregisterComponent } from './dregister/dregister.component';
import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { PconsultancyReportComponent } from './pconsultancy-report/pconsultancy-report.component';
import { PtestReportComponent } from './ptest-report/ptest-report.component';
import { RegisterComponent } from './register/register.component';

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
  //{path: '',redirectTo:'Dashboard' ,pathMatch:'full'},
  //{path: '',component:AppComponent ,pathMatch:'full'},
  {path:'add-consultancy-report',component:AddpconsultancyReportComponent},
  {path:'add-test-report',component:AddtestReportComponent},
  {path:'dregister',component:DregisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
