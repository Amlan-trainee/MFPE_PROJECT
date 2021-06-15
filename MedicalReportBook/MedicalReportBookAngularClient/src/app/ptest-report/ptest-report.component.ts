import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { TestReport } from '../Source/test-report';

@Component({
  selector: 'app-ptest-report',
  templateUrl: './ptest-report.component.html',
  styleUrls: ['./ptest-report.component.css']
})
export class PtestReportComponent implements OnInit {
  treports:TestReport[] = [];
  constructor(private http :HttpClient) {
  
  }

  ngOnInit(): void {
    this.http.get('http://localhost:57071/api/Patient/AddConsultancyReport').subscribe(
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
