import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl,FormGroup,FormBuilder,Validator,NgForm, Validators } from '@angular/forms';
import { ConsultancyReport } from '../Source/consultancy-report';
import { TestReport } from '../Source/test-report';


@Component({
  selector: 'app-addtest-report',
  templateUrl: './addtest-report.component.html',
  styleUrls: ['./addtest-report.component.css']
})
export class AddtestReportComponent implements OnInit {

  frmCReport:FormGroup;
  constructor(private http:HttpClient,private formBuilder:FormBuilder) {
    this.frmCReport=this.formBuilder.group({
     Lr_Id:new FormControl('',Validators.required) ,
     DoctorName :new FormControl('',[Validators.required,Validators.minLength(3)]),
     LabName:new FormControl('',[Validators.required,Validators.minLength(3)]),
     DateofTest:new FormControl('',Validators.required),
     TestName:new FormControl('',[Validators.required,Validators.minLength(3)]),
     LabReport:new FormControl('',Validators.required),
     IsActive:new FormControl('',Validators.required),
    UID:new FormControl('',Validators.required)

    });
   }
   get f(){
     return this.frmCReport.controls;
   }
   SaveReport(){
    if(this.frmCReport.valid){
      let p:TestReport=this.frmCReport.value as TestReport;
      this.http.post('add test report wala api ',p).subscribe(data=>{
        alert('test report saved');
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