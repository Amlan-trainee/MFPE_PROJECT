import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ConsultancyReport } from '../Source/consultancy-report';

@Component({
  selector: 'app-doctor-consultancyreport',
  templateUrl: './doctor-consultancyreport.component.html',
  styleUrls: ['./doctor-consultancyreport.component.css']
})
export class DoctorConsultancyreportComponent implements OnInit {
  reports:ConsultancyReport[] = [];
  formData: any;
  
  constructor(private http :HttpClient) {
  
  }


  public url:string="http://localhost:57071/api/Patient/ViewConsultancyReport/";

  public urlt:string="";

  public UserId:string="";


  ngOnInit(): void {
    this.formData = new FormGroup({
      name    : new FormControl()
  });
    
  }

  onSubmit(data: { UserId: string; DiseaseName: string; }){ 
     this.urlt= this.url+data.UserId+'/'+data.DiseaseName;

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

}
