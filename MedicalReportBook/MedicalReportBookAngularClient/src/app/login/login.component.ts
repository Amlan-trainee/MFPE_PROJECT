import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../login.service';
import { AdminAuthService } from '../Services/admin-auth.service';
import { AuthService } from '../Services/auth.service';
import { DoctorAuthService } from '../Services/doctor-auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  public model : any={};

  errorMessage: string = "";
  constructor(private router:Router,private LoginService:LoginService,private as:AuthService,private ass:AdminAuthService,private das:DoctorAuthService) { }

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
        if(data.Result == 'User')
        {
          // this.router.navigate(['/Landing']);
          this.as.doLogin(true);
          localStorage.setItem('UId',data.Id);
          localStorage.setItem('UType',data.Result);
          alert("Login successful for User");
          this.router.navigateByUrl("/");

          // debugger;
        }

        else if(data.Result == 'Admin')
        {
          // this.router.navigate(['/Landing']);
          this.ass.doAdminLogin(true);
          localStorage.setItem('UId',data.Id);
          localStorage.setItem('UType',data.Result);
          alert("Login successful for Admin");
          this.router.navigateByUrl("/");

          // debugger;
        }

        else if(data.Result == 'Doctor')
        {
          // this.router.navigate(['/Landing']);
          this.das.doDoctorLogin(true);
          localStorage.setItem('UId',data.Id);
          localStorage.setItem('UType',data.Result);
          alert("Login successful for Doctor ");
          this.router.navigateByUrl("/");

          // debugger;
        }
        else{
          this.errorMessage = data.Message;
          this.as.doLogin(false);
          alert("Error while Login");
          this.router.navigateByUrl("/");

        }
      },
      error => {
        this.errorMessage = error.message;
        alert("Wrong Credential");
      });
  };
}
// function Id(Id: any, Id: any) {
//   throw new Error('Function not implemented.');
// }

