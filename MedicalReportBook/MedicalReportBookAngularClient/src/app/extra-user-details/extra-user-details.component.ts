import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl,FormGroup,FormBuilder,Validator,NgForm, Validators } from '@angular/forms';
import { ExtraUserDetails } from '../Source/extrauserdetails';
import { Router } from '@angular/router';

@Component({
  selector: 'app-extra-user-details',
  templateUrl: './extra-user-details.component.html',
  styleUrls: ['./extra-user-details.component.css']
})
export class ExtraUserDetailsComponent implements OnInit {
  frmXReport:FormGroup;
  url:string='http://localhost:57071/api/AppUser/UserDetails';
  constructor(private http:HttpClient,private formBuilder:FormBuilder,private router:Router) {
    this.frmXReport=this.formBuilder.group({
      User_Id:localStorage.getItem('UId'),
      BloodGroup:new FormControl('',Validators.required),
      Height:new FormControl(),
      Weight:new FormControl(),
    })
   }
   get f(){
    return this.frmXReport.controls;
  }


  ngOnInit(): void {
  }


  SaveReport(){
    // const fd=new FormData();
    let p:ExtraUserDetails=this.frmXReport.value as ExtraUserDetails;
    if(this.frmXReport.valid){
      this.http.post(this.url,p).subscribe(data=>{
        alert('Details saved');
        this.router.navigateByUrl("/");
      },error=>{
        alert('You have already updated your details');
      })
    }
    
  }


}
