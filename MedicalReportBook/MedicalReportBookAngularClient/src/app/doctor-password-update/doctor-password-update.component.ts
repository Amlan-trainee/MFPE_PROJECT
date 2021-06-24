import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UpdatePassword } from '../Source/update-password';

@Component({
  selector: 'app-doctor-password-update',
  templateUrl: './doctor-password-update.component.html',
  styleUrls: ['./doctor-password-update.component.css']
})
export class DoctorPasswordUpdateComponent implements OnInit {
  frmXReport:FormGroup;
  url:string='http://localhost:57071/api/Doctor/ChangePassword';

  constructor(private http:HttpClient,private formBuilder:FormBuilder) { 
    this.frmXReport=this.formBuilder.group({
      User_Id:localStorage.getItem('UId'),
      OldPassword:new FormControl(),
      NewPassword:new FormControl(),
      ConfirmPassword:new FormControl()
    })
  }

  get f(){
    return this.frmXReport.controls;
  }

  ngOnInit(): void {
  }
  SaveReport(){
    // const fd=new FormData();
    let p:UpdatePassword=this.frmXReport.value as UpdatePassword;
    if(this.frmXReport.valid){
      this.http.put(this.url,p).subscribe(data=>{
        alert('Password Updated');
      },error=>{
        alert('Update Unsuccessful');
      })
    }
    
  }

}
