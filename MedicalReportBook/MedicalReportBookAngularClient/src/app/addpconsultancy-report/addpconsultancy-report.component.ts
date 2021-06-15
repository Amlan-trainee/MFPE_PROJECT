import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl,FormGroup,FormBuilder,Validator,NgForm, Validators } from '@angular/forms';
import { ConsultancyReport } from '../Source/consultancy-report';

@Component({
  selector: 'app-addpconsultancy-report',
  templateUrl: './addpconsultancy-report.component.html',
  styleUrls: ['./addpconsultancy-report.component.css']
})
export class AddpconsultancyReportComponent implements OnInit {
frmCReport:FormGroup;
  constructor(private http:HttpClient,private formBuilder:FormBuilder) {
    this.frmCReport=this.formBuilder.group({
     DoctorName :new FormControl('',[Validators.required,Validators.minLength(3)]),
     DateofConsultancy:new FormControl('',Validators.required),
     ClinicName:new FormControl('',[Validators.required,Validators.minLength(3)]),
     DiseaseName:new FormControl('',[Validators.required,Validators.minLength(3)]),
     Prescription:new FormControl('',Validators.required),
     IsActive:new FormControl('',Validators.required),
    UserId:new FormControl('',Validators.required)

    });
   }
   get f(){
     return this.frmCReport.controls;
   }
   SaveReport(){
    if(this.frmCReport.valid){
      let p:ConsultancyReport=this.frmCReport.value as ConsultancyReport;
      this.http.post('yaha p api daalna h',p).subscribe(data=>{
        alert('product saved');
      },error=>{
        alert('not saved');
      })

    }
    else{
     alert('Invalid form entries');
    }
   }

  ngOnInit(): void {
  }

}
