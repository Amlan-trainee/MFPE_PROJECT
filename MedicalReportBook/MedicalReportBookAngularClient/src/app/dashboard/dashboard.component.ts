import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AdminAuthService } from '../Services/admin-auth.service';
import { AuthService } from '../Services/auth.service';
import { DoctorAuthService } from '../Services/doctor-auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit , OnDestroy {
  subs: Subscription = new Subscription;
  asubs: Subscription = new Subscription;
  userLoggedIn: boolean = false;
  adminLoggedIn: boolean = false;
  dsubs: Subscription = new Subscription;
  doctorLoggedIn: boolean = false;
  constructor(private as:AuthService,private ass:AdminAuthService,private das:DoctorAuthService,private router:Router) { }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
    this.asubs.unsubscribe();
    this.dsubs.unsubscribe();
  
  }

  ngOnInit(): void {
    this.subs=this.as.OnLoggedIn.subscribe(result => this.userLoggedIn = result);

    this.asubs=this.ass.OnAdminLoggedIn.subscribe(result => this.adminLoggedIn = result);

    this.dsubs=this.das.OnDoctorLoggedIn.subscribe(result => this.doctorLoggedIn = result);
  }

  logout(){
    this.as.doLogin(false);
    this.ass.doAdminLogin(false);
    this.das.doDoctorLogin(false);
    this.router.navigateByUrl("/");
  }

}
