import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login.service';    
import {Register} from '../register';    
import {Observable} from 'rxjs';    
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import{FormsModule} from '@angular/forms'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  data = false;
  UserForm: any;    
  massage: string = "";
      
  constructor(private formbulider: FormBuilder,private loginService:LoginService) { }    
    
  ngOnInit() {    
    this.UserForm = this.formbulider.group({    
      UserId: ['', [Validators.required]],    
      FirstName: ['', [Validators.required]],
      MiddleName: ['', [Validators.required]],
      LastName: ['', [Validators.required]],
      Gender: ['', [Validators.required]], 
      PhoneNumber: ['', [Validators.required]],    
      Address: ['', [Validators.required]],
      UserType: ['', [Validators.required]],     
      Password: ['', [Validators.required]],    
      Email: ['', [Validators.required]],    
          
    });    
  }    
   onFormSubmit()    
  {    
    const user = this.UserForm.value;    
    this.Createemployee(user);    
  }    
  Createemployee(register:Register)    
  {    
  this.loginService.CreateUser(register).subscribe(    
    ()=>    
    {    
      this.data = true;    
      this.massage = 'Data saved Successfully';    
      this.UserForm.reset();    
    });    
  }    
}
