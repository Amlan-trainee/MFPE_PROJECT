import { Component, OnInit } from '@angular/core';
import { ConsultancyReport } from '../Source/consultancy-report';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-pconsultancy-report',
  templateUrl: './pconsultancy-report.component.html',
  styleUrls: ['./pconsultancy-report.component.css']
})
export class PconsultancyReportComponent implements OnInit {
  reports:ConsultancyReport[] = [];
  constructor(private http :HttpClient) {
  
  }

  ngOnInit(): void {
    this.http.get('').subscribe(
      (data)=>{this.reports= data as ConsultancyReport[];},
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
