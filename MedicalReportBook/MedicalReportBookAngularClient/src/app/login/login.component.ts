import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../login.service';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  public model : any={};

  errorMessage: string = "";
  constructor(private router:Router,private LoginService:LoginService,private as:AuthService) { }

  get f(){
    return this.model.controls;
  }


  ngOnInit() {
   // document.body.classList.add('bg-img');
    sessionStorage.removeItem('EmailId');
    sessionStorage.clear();
  }
  login(){
    // debugger;
    this.LoginService.Login(this.model).subscribe(
      data => {
        // debugger;
        if(data.Status=="Success")
        {
          // this.router.navigate(['/Landing']);
          this.as.doLogin(true);

          // debugger;
        }
        else{
          this.errorMessage = data.Message;
          this.as.doLogin(false);
        }
      },
      error => {
        this.errorMessage = error.message;
      });
  };
}
