import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  subs: Subscription = new Subscription;
  userLoggedIn: boolean = false;
  constructor(private as:AuthService) { }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  
  }

  ngOnInit(): void {
    this.subs=this.as.OnLoggedIn.subscribe(result => this.userLoggedIn = result);
  }

  logout(){
    this.as.doLogin(false);
  }

}
