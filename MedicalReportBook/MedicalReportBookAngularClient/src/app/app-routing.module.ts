import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AfterLoginComponent } from './after-login/after-login.component';
import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { PconsultancyReportComponent } from './pconsultancy-report/pconsultancy-report.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {
    path: '',
    component: LandingComponent,

  },
  {
    path: 'login',
    component: LoginComponent,



  },
  {
    path:'register',
    component: RegisterComponent,
  },
  {
    path:'logout',
    component:LandingComponent
  },
  {
    path:'consultancy_report',
    component:PconsultancyReportComponent

  },
  {
    path:'after_login',
    component:AfterLoginComponent
  },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
