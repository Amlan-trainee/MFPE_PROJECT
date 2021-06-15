import { Component, OnInit } from '@angular/core';
import { ConsultancyReport } from '../Source/consultancy-report';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-pconsultancy-report',
  templateUrl: './pconsultancy-report.component.html',
  styleUrls: ['./pconsultancy-report.component.css']
})
export class PconsultancyReportComponent implements OnInit {
  reports:ConsultancyReport[] = [];
  formData: any;
  
  constructor(private http :HttpClient) {
  
  }


  public url:string="http://localhost:57071/api/Patient/ViewConsultancyReport/";

  public urlt:string="";


  ngOnInit(): void {
    this.formData = new FormGroup({
      name    : new FormControl()
  });
    this.http.get(this.urlt).subscribe(
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

  onSubmit(data: { DiseaseName: string; }){ 
     this.urlt= this.url+data.DiseaseName   ;
  }
}
