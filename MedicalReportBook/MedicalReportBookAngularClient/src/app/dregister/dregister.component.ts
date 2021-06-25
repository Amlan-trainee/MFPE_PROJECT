import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from '../login.service';
import { Register } from '../register';

@Component({
  selector: 'app-dregister',
  templateUrl: './dregister.component.html',
  styleUrls: ['./dregister.component.css']
})
export class DregisterComponent implements OnInit {
  data = false;
  UserForm: any;
  massage: string = "";
  // userSubmitted: boolean = false;

  constructor(private formbulider: FormBuilder,private loginService:LoginService,private formBuilder:FormBuilder,private router:Router) { }

  ngOnInit() {
    this.UserForm = this.formbulider.group({

      FirstName: ['', [Validators.required]],
      MiddleName: ['', [Validators.required]],
      LastName: ['', [Validators.required]],
      Gender: ['', [Validators.required]],
      PhoneNumber: ['', [Validators.required,Validators.maxLength(10)]],
      Address: ['', [Validators.required]],
      UserType:'Doctor',
      Password: ['', [Validators.required,Validators.minLength(8)]],
      ConfirmPassword:['', [Validators.required,Validators.minLength(8)]],
      EmailId: ['', [Validators.required,Validators.email]],

    });
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
      alert('Doctor Registered');
      this.router.navigateByUrl("/");
    }),
    error=>{
      alert('Doctor Registeration Failed');
    });
  }
}
