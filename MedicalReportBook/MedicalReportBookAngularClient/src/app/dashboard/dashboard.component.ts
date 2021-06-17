import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AdminAuthService } from '../Services/admin-auth.service';
import { AuthService } from '../Services/auth.service';

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
  constructor(private as:AuthService,private ass:AdminAuthService) { }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  
  }

  ngOnInit(): void {
    this.subs=this.as.OnLoggedIn.subscribe(result => this.userLoggedIn = result);

    this.asubs=this.ass.OnAdminLoggedIn.subscribe(result => this.adminLoggedIn = result);
  }

  logout(){
    this.as.doLogin(false);
    this.ass.doAdminLogin(false);
  }

}
