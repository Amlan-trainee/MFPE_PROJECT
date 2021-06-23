import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl,FormGroup,FormBuilder,Validator,NgForm, Validators } from '@angular/forms';
import { ExtraUserDetails } from '../Source/extrauserdetails';

@Component({
  selector: 'app-extra-user-details',
  templateUrl: './extra-user-details.component.html',
  styleUrls: ['./extra-user-details.component.css']
})
export class ExtraUserDetailsComponent implements OnInit {
  frmTReport:FormGroup;
  constructor(private http:HttpClient,private formBuilder:FormBuilder) {
    this.frmTReport=this.formBuilder.group({
      User_Id: new FormControl('',[Validators.required,Validators.minLength(3)]),
      BloodGroup:new FormControl('',[Validators.required,Validators.minLength(3)]),
      Height:new FormControl('',Validators.required),
      Weight:new FormControl('',Validators.required),
    })
   }
   get f(){
    return this.frmTReport.controls;
  }


  ngOnInit(): void {
  }
  SaveReport(){
    const fd=new FormData()
    if(this.frmTReport.valid){
      this.http.post('pi',fd).subscribe(data=>{
        alert('details saved');
      },error=>{
        alert('details not saved');
      })
    }
  }


}
