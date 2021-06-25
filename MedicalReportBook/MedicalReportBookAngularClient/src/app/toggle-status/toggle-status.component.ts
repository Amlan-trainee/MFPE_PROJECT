import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { StatusToggle } from '../Source/status-toggle';

@Component({
  selector: 'app-toggle-status',
  templateUrl: './toggle-status.component.html',
  styleUrls: ['./toggle-status.component.css']
})
export class ToggleStatusComponent implements OnInit {
  frmXReport:FormGroup;
  url:string="http://localhost:57071/api/Patient/LockUnlockCrReport";


  constructor(private http: HttpClient,private actr:ActivatedRoute,private formBuilder:FormBuilder,private router:Router) {
    this.frmXReport=this.formBuilder.group({
      Report_Id:this.actr.snapshot.paramMap.get('R-Id'),
      IsActive:new FormControl()
    });
    
  
   }

  ngOnInit(): void {
  }

  get f(){
    return this.frmXReport.controls;
  }

  OnSubmit(){
    let p:StatusToggle=this.frmXReport.value as StatusToggle;
    if(this.frmXReport.valid){
      this.http.put(this.url,p).subscribe(data=>{
        alert('Toggled Successfully');
        this.router.navigateByUrl("/consultancy-report");
      },error=>{
        alert('Toggle Unsuccessful');
      })
    }

  }
}


