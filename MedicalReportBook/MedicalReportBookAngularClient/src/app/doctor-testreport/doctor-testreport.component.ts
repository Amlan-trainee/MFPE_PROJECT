import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { TestReport } from '../Source/test-report';

@Component({
  selector: 'app-doctor-testreport',
  templateUrl: './doctor-testreport.component.html',
  styleUrls: ['./doctor-testreport.component.css']
})
export class DoctorTestreportComponent implements OnInit {

  treports:TestReport[] = [];
  formData:any;
  constructor(private http :HttpClient) {
  
  }
  public url:string="http://localhost:57071/api/Patient/ViewLabReport/";

  public urlt:string="";

  public UserId:string="";

  ngOnInit(): void {
    this.formData=new FormGroup({
      name    : new FormControl()
    });

  }

    ontestsubmit(data: { UserId: string;TestName: string; }){ 
      this.urlt= this.url+data.UserId+'/'+data.TestName;
 
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
