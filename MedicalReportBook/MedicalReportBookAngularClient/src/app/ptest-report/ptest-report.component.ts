import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { TestReport } from '../Source/test-report';
import { FormControl, FormGroup } from '@angular/forms';
@Component({
  selector: 'app-ptest-report',
  templateUrl: './ptest-report.component.html',
  styleUrls: ['./ptest-report.component.css']
})
export class PtestReportComponent implements OnInit {
  treports:TestReport[] = [];
  formData:any;
  constructor(private http :HttpClient) {
  
  }
  public url:string="http://localhost:57071/api/Patient/ViewLabReport/";

  public urlt:string="";

  public UserId=localStorage.getItem('UId');

  ngOnInit(): void {
    this.formData=new FormGroup({
      name    : new FormControl()
    });

  }

    ontestsubmit(data: { TestName: string; }){ 
      this.urlt= this.url+this.UserId+'/'+data.TestName;
 
      this.http.get(this.urlt).subscribe(
       (data)=>{this.treports= data as TestReport[];},
       (err)=>{
         if(err.status===404){
           alert('Api not available');
         }
         else if(err.status===500){
           alert('Server Error');
         }
       }

      );
    }
  }
  


