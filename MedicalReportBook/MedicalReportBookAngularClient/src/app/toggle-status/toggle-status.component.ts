import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-toggle-status',
  templateUrl: './toggle-status.component.html',
  styleUrls: ['./toggle-status.component.css']
})
export class ToggleStatusComponent implements OnInit {
  url:string="http://localhost:57071/api/Patient/LockUnlockCrReport/";
  ReportId: number;
  Status: boolean;

  constructor(private http: HttpClient,private actr:ActivatedRoute) {
    this.ReportId=Number(this.actr.snapshot.paramMap.get('R-Id'));
    this.Status=Boolean(this.actr.snapshot.paramMap.get('Status'));
  
   }

  ngOnInit(): void {
  }

  OnSubmit(){
    this.http.put(this.url+this.ReportId,true).subscribe(data=>{},error=>{});

  }

}
