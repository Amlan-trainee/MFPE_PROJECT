import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { StatusToggle } from '../Source/status-toggle';

@Component({
  selector: 'app-toggle-status',
  templateUrl: './toggle-status.component.html',
  styleUrls: ['./toggle-status.component.css']
})
export class ToggleStatusComponent implements OnInit {
  frmXReport:FormGroup;
  url:string="http://localhost:57071/api/Patient/LockUnlockCrReport/";
  ReportId: number;

  constructor(private http: HttpClient,private actr:ActivatedRoute,private formBuilder:FormBuilder) {
    this.ReportId=Number(this.actr.snapshot.paramMap.get('R-Id'));
    this.frmXReport=this.formBuilder.group({
      Report_Id:this.ReportId,
      IsActive:new FormControl(false)
    })
    
  
   }

  ngOnInit(): void {
  }

  OnSubmit(){
    let p:StatusToggle=this.frmXReport.value as StatusToggle;
    if(this.frmXReport.valid){
      this.http.put(this.url,p).subscribe(data=>{
        alert('Password Updated');
      },error=>{
        alert('Update Unsuccessful');
      })
    }

  }
}


