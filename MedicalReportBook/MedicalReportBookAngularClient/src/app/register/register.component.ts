import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login.service';
import {Register} from '../register';
import {Observable} from 'rxjs';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import{FormsModule} from '@angular/forms'
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  data = false;
  UserForm: any;
  massage: string = "";
  // userSubmitted: boolean = false;

  constructor(private formbulider: FormBuilder,private loginService:LoginService,private formBuilder:FormBuilder,private router:Router) { }

  ngOnInit() {
    this.UserForm = this.formbulider.group({

      FirstName: ['', [Validators.required]],
      MiddleName: [],
      LastName: ['', [Validators.required]],
      Gender: ['', [Validators.required]],
      PhoneNumber: ['', [Validators.required,Validators.maxLength(10)]],
      Address: ['', [Validators.required]],
      UserType:'User',
      Password: ['',[Validators.required,Validators.minLength(8)]],
     
      ConfirmPassword:['', [Validators.required,Validators.minLength(8)]],
      EmailId: ['', [Validators.required,Validators.email]],

    },
   
    );
  }
  // passwordMatchValidator(frm: FormGroup) {
  //   return frm.controls['Password'].value === frm.controls['ConfirmPassword'].value ? null : {'mismatch': true};
  // }
   onFormSubmit()
  {
    // this.userSubmitted=true;
    const user = this.UserForm.value;
    this.Createemployee(user);
  }

  get f(){
    return this.UserForm.controls;
  }


  Createemployee(register:Register)
  { this.loginService.CreateUser(register).subscribe(
    (data=>
    {
      this.data = true;
      this.massage = 'Data saved Successfully';
      this.UserForm.reset();
      alert('User Registered');
      this.router.navigateByUrl("/login");
    }),
    error=>{
      alert('User Registration Failed');
    });
  }
  
 
}
